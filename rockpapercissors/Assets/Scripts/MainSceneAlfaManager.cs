using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainSceneAlfaManager : MonoBehaviour {
    [SerializeField] private PlayerManager LeftPlayerManager;
    [SerializeField] private PlayerManager RightPlayerManager;

    [SerializeField] private CardManager CardManager;
    [SerializeField] private ResourceManager ResourceManager;
    [SerializeField] private SpawnManager SpawnManager;
    [SerializeField] private NavMeshSurface NavMeshSurface;

    private PlayerState PlayerLeftState;
    private PlayerState PlayerRightState;

    [SerializeField] private LayerMask EnemyBuildingPlayerOneLayerMask;
    [SerializeField] private LayerMask EnemyBuildingsPlayerTwoLayerMask;

    [SerializeField] private LayerMask PlayerOneLayerMask;
    [SerializeField] private LayerMask PlayerTwoLayerMask;


    private void Start() {
        BattleManager.ResetBattleManager();
        NavMeshSurfaceManager.NavMeshSurface = NavMeshSurface;
        NavMeshSurfaceManager.NavMeshSurface.BuildNavMesh();

        PlayerLeftState = new PlayerState();
        PlayerRightState = new PlayerState();

        PlayerLeftState.PlayerType = PlayerType.PlayerOne;
        PlayerRightState.PlayerType = PlayerType.PlayerTwo;

        PlayerLeftState.LayerMask = PlayerOneLayerMask;
        PlayerRightState.LayerMask = PlayerTwoLayerMask;

        BattleManager.Instance.UnitsOnField.Add(PlayerLeftState.PlayerType, new List<UnitController>());
        BattleManager.Instance.UnitsOnField.Add(PlayerRightState.PlayerType, new List<UnitController>());

        BattleManager.Instance.BuildingsOnfield.Add(PlayerLeftState.PlayerType, new List<BuildingController>());
        BattleManager.Instance.BuildingsOnfield.Add(PlayerRightState.PlayerType, new List<BuildingController>());

        BattleManager.Instance.BuildingsOnfield[PlayerType.PlayerOne]
            .Add(LeftPlayerManager.MainSceneViewManagerPlayer.BaseView);
        BattleManager.Instance.BuildingsOnfield[PlayerType.PlayerOne]
            .Add(LeftPlayerManager.MainSceneViewManagerPlayer.WallView);

        BattleManager.Instance.BuildingsOnfield[PlayerType.PlayerTwo]
            .Add(RightPlayerManager.MainSceneViewManagerPlayer.BaseView);
        BattleManager.Instance.BuildingsOnfield[PlayerType.PlayerTwo]
            .Add(RightPlayerManager.MainSceneViewManagerPlayer.WallView);

        BattleManager.Instance.EnemyBuildingLayerMask.Add(PlayerType.PlayerOne, EnemyBuildingPlayerOneLayerMask);
        BattleManager.Instance.EnemyBuildingLayerMask.Add(PlayerType.PlayerTwo, EnemyBuildingsPlayerTwoLayerMask);

        PlayerLeftState.PlayerManager = LeftPlayerManager;
        PlayerRightState.PlayerManager = RightPlayerManager;

        PlayerLeftState.EnemyBasePosition =
            RightPlayerManager.MainSceneViewManagerPlayer.BaseFinishPoint.transform.position;
        PlayerRightState.EnemyBasePosition =
            LeftPlayerManager.MainSceneViewManagerPlayer.BaseFinishPoint.transform.position;

        PlayerLeftState.EnemyWallPositions = RightPlayerManager.MainSceneViewManagerPlayer.GetWallPositions();
        PlayerRightState.EnemyWallPositions = LeftPlayerManager.MainSceneViewManagerPlayer.GetWallPositions();

        CardManager.Init(SpawnManager);

        LeftPlayerManager.Init(PlayerLeftState);
        RightPlayerManager.Init(PlayerRightState);

        PlayerLeftState.UpdateCards(CardManager.UpdateCards(PlayerLeftState, true));
        PlayerRightState.UpdateCards(CardManager.UpdateCards(PlayerRightState, true));
    }

    private void Update() {
        // parse input
        PlayerLeftState.UpdatePlayerStateBasedOnPlayerInput(LeftPlayerManager.GetInputsThisFrame());
        PlayerRightState.UpdatePlayerStateBasedOnPlayerInput(RightPlayerManager.GetInputsThisFrame());

        CardManager.TryToBuyCard(PlayerLeftState);
        CardManager.TryToBuyCard(PlayerRightState);

        // update cards
        PlayerLeftState.UpdateCards(CardManager.UpdateCards(PlayerLeftState));
        PlayerRightState.UpdateCards(CardManager.UpdateCards(PlayerRightState));

        // update resources
        ResourceManager.UpdateTime();
        ResourceManager.UpdateResources(PlayerLeftState);
        ResourceManager.UpdateResources(PlayerRightState);

        // update view
        LeftPlayerManager.UpdateView(PlayerLeftState);
        RightPlayerManager.UpdateView(PlayerRightState);
    }
}