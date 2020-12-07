using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class UnitController : MonoBehaviour {
    public int UnitHP = 100;
    private int ReferenceSizeHP = 333;
    public int AttackDamage = 30;
    [SerializeField] private UnitType UnitType;
    public PlayerType PlayerType;
    [SerializeField] private NavMeshAgent NavMeshAgent;
    [NonSerialized] public Vector3 EnemyBasePosition;
    [NonSerialized] public Vector3 EnemyWallPosition;
    public float EnemyDetectionRadious = 5.0f;
    public float AttackRadious = 4.0f;
    public float FinishPointRadious = 3.0f;
    [SerializeField] private MeshRenderer MeshRenderer;

    private float AttackCooldown = 3.0f;
    private float AttackTime = 0.0f;

    private List<Vector3> DirectionPoitnsQueue = new List<Vector3>();

    [Header("Attacking")] public bool IsChasingEnemy = false;
    public bool AttackingBuilding = false;
    public UnitController ChasedEnemy = null;
    public BuildingController AttackedBuilding = null;

    [SerializeField] private Transform UnitTransform;
    [SerializeField] private Material UnitMaterial;


    [SerializeField] private LayerMask LAyermask;


    public void UpdateView() {
        float yScale = ((float)UnitHP / ReferenceSizeHP);
        UnitTransform.localScale = new Vector3(UnitTransform.localScale.x, yScale, UnitTransform.localScale.z);
    }

    public void AttackThisUnit(int attackDamage, UnitType unitType) {
        if (BattleManager.Instance.UnitTypeToUnitTypeBonus[UnitType] == unitType) {
            attackDamage /= 2;
        }

        UnitHP -= attackDamage;
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(Color.cyan.r, Color.cyan.g, Color.cyan.b, 0.35f);
        Gizmos.DrawSphere(transform.position, EnemyDetectionRadious);
        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.35f);
        Gizmos.DrawSphere(transform.position, AttackRadious);
        Gizmos.color = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.35f);
        Gizmos.DrawSphere(transform.position, FinishPointRadious);
    }

    private void Start() {
        UnitMaterial = MeshRenderer.material;
        DirectionPoitnsQueue.Add(EnemyBasePosition);
        DirectionPoitnsQueue.Add(EnemyWallPosition);

        MeshRenderer.material.color = BattleManager.Instance.PlayerColors[PlayerType];
        NavMeshAgent.SetDestination(DirectionPoitnsQueue.Last());
    }

    private void Update() {
        if (DirectionPoitnsQueue.Count == 0) return;

        if (UnitHP <= 0) {
            BattleManager.Instance.UnitsOnField[PlayerType].Remove(this);
            Destroy(gameObject);
            return;
        }

        UpdateView();

        if (Vector3.Distance(DirectionPoitnsQueue.Last(), transform.position) <= FinishPointRadious) {
            DirectionPoitnsQueue.Remove(DirectionPoitnsQueue.Last());
            if (DirectionPoitnsQueue.Count == 0) {
                ExitGame();
                return;
            }

            NavMeshAgent.SetDestination(DirectionPoitnsQueue.Last());
        }

        if (IsChasingEnemy && ChasedEnemy == null) {
            IsChasingEnemy = false;
            AttackTime = 0.0f;
            NavMeshAgent.SetDestination(DirectionPoitnsQueue.Last());
        }

        if (AttackingBuilding && AttackedBuilding.IsDestroyed()) {
            AttackingBuilding = false;
            AttackTime = 0.0f;
        }


        List<UnitController> enemies = new List<UnitController>();
        foreach (var unitsOnField in BattleManager.Instance.UnitsOnField) {
            if (unitsOnField.Key != PlayerType) {
                enemies.AddRange(unitsOnField.Value);
            }
        }

        if (enemies.Count > 0) {
            UnitController closestEnemy = GetClosestEnemy(enemies);
            float distance = Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position);
            if (distance <= EnemyDetectionRadious) {
                IsChasingEnemy = true;
                if (ChasedEnemy != closestEnemy) {
                    ChasedEnemy = closestEnemy;
                    AttackTime = 0.0f;
                }

                NavMeshAgent.SetDestination(closestEnemy.transform.position);
            }

            if (distance <= AttackRadious) {
                AttackTime += Time.deltaTime;
                TryToAttack(closestEnemy);
            }
        }

        if (!IsChasingEnemy) {
            LAyermask = BattleManager.Instance.EnemyBuildingLayerMask[PlayerType];

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, AttackRadious,
                BattleManager.Instance.EnemyBuildingLayerMask[PlayerType]);
            if (hitColliders.Length > 0) {
                AttackTime += Time.deltaTime;
                AttackingBuilding = true;
                TryToAttack(hitColliders[0]);
            }
        }

        ColorUnitBasedOnAttackCooldown();
    }

    private void ColorUnitBasedOnAttackCooldown() {
        UnitMaterial.color = new Color(UnitMaterial.color.r, UnitMaterial.color.g,
            MyMathUtils.Linear(AttackTime, 0.0f, AttackCooldown, 0, 1)
            , UnitMaterial.color.a);
    }

    private UnitController GetClosestEnemy(List<UnitController> enemies) {
        int bestTarget = 0;
        float closestDistanceSqr = Mathf.Infinity;

        Vector3 currentPosition = transform.position;
        for (int i = 0;
            i < enemies.Count;
            i++) {
            Vector3 directionToTarget = enemies[i].gameObject.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = i;
            }
        }

        return enemies[bestTarget];
    }

    private void TryToAttack(UnitController enemy) {
        if (AttackTime >= AttackCooldown) {
            AttackTime = 0.0f;
            enemy.AttackThisUnit(AttackDamage, UnitType);
        }
    }

    private void TryToAttack(Collider enemy) {
        BuildingController buildingController = enemy.GetComponent<BuildingController>();
        if (AttackedBuilding != buildingController) {
            AttackedBuilding = buildingController;
            AttackTime = 0.0f;
        }

        if (AttackTime >= AttackCooldown) {
            AttackTime = 0.0f;
            enemy.GetComponent<BuildingController>().AttackThisBuilding(AttackDamage);
        }
    }

    void ExitGame() {
        BattleManager.Instance.WonPlayer = PlayerType;
        SceneManager.LoadScene("MainMenu");
    }
}