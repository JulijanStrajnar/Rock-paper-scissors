using UnityEngine;

public class BaseView : BuildingController {
    private float AttackCooldown = 2.3f;
    private float AttackTime = 0.0f;

    public bool IsAtacckingEnemy = false;
    public UnitController AtacckedEnemy = null;
    public PlayerType PlayerType;

    [SerializeField] private Transform AttackPosition;
    [SerializeField] private LayerMask UnitLayerMask;
    private Material BaseMaterial;
    [SerializeField] private MeshRenderer MeshRenderer;

    public override void Init(PlayerState playerState) {
        base.Init(playerState);

        ReferenceSize = playerState.BaseHP;
        BaseMaterial = MeshRenderer.material;
        PlayerType = playerState.PlayerType;
    }

    public override bool IsDestroyed() {
        return PlayerState.BaseHP <= 0;
    }

    private void ColorUnitBasedOnAttackCooldown() {
        BaseMaterial.color = new Color(BaseMaterial.color.r, BaseMaterial.color.g,
            MyMathUtils.Linear(AttackTime, 0.0f, AttackCooldown, 0, 1)
            , BaseMaterial.color.a);
    }

    public override void AttackThisBuilding(int damage) {
        PlayerState.BaseHP -= damage;
        if (PlayerState.BaseHP <= 0) {
            PlayerState.BaseHP = 0;
            BuldingCollider.enabled = false;
        }
    }

    public void UpdateView() {
        bool updatenavMesh = false;
        float yScale = (float) PlayerState.BaseHP / ReferenceSize;
        bool baseDestroyed = yScale <= 0 && BuldingTransform.localScale.y > 0;
        if (baseDestroyed) {
            updatenavMesh = true;
        }

        BuldingTransform.localScale = new Vector3(BuldingTransform.localScale.x, yScale, BuldingTransform.localScale.z);
        if (updatenavMesh) {
            NavMeshSurfaceManager.NavMeshSurface.BuildNavMesh();
        }
    }

    private void Update() {
        if (IsAtacckingEnemy && AtacckedEnemy != null) {
            AttackTime += Time.deltaTime;
            if (AttackTime >= AttackCooldown) {
                AttackTime = 0;
                AtacckedEnemy.AttackThisUnit(50, UnitType.Building);
            }
        }

        if (IsAtacckingEnemy && AtacckedEnemy == null) {
            IsAtacckingEnemy = false;
            AttackTime = 0.0f;
        }

        if (!IsAtacckingEnemy) {
            Collider[] hitColliders = Physics.OverlapBox(AttackPosition.transform.position, new Vector3(6, 2, 35),
                Quaternion.identity, UnitLayerMask);

            foreach (var hitCollider in hitColliders) {
                if (hitCollider.gameObject.GetComponent<UnitController>().PlayerType != PlayerType) {
                    AtacckedEnemy = hitCollider.gameObject.GetComponent<UnitController>();
                    IsAtacckingEnemy = true;
                }
            }
        }

        ColorUnitBasedOnAttackCooldown();

        ExtDebug.DrawBox(AttackPosition.transform.position, new Vector3(6, 2, 35), Quaternion.identity, Color.blue);
    }
}