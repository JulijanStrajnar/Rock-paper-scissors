using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] private UnitController RockController;
    [SerializeField] private UnitController PaperController;
    [SerializeField] private UnitController SizzorsController;

    public void SpawnRock(int rewardAmount, PlayerState playerState) {
        for (int i = 0; i < rewardAmount; i++) {
            UnitController rockController = Instantiate(RockController,
                playerState.PlayerManager.MainSceneViewManagerPlayer.GetSpawnPoints()[playerState.SelectedLane]);
            rockController.EnemyBasePosition = playerState.EnemyBasePosition;
            rockController.EnemyWallPosition = playerState.EnemyWallPositions[playerState.SelectedLane];
            rockController.PlayerType = playerState.PlayerType;
            rockController.UnitHP = playerState.UnitHP[UnitType.Rock];
            rockController.AttackDamage = playerState.UnitDamage[UnitType.Rock];
            BattleManager.Instance.UnitsOnField[playerState.PlayerType].Add(rockController);
        }
    }

    public void SpawnPaper(int rewardAmount, PlayerState playerState) {
        for (int i = 0; i < rewardAmount; i++) {
            UnitController paperController = Instantiate(PaperController,
                playerState.PlayerManager.MainSceneViewManagerPlayer.GetSpawnPoints()[playerState.SelectedLane]);
            paperController.EnemyBasePosition = playerState.EnemyBasePosition;
            paperController.EnemyWallPosition = playerState.EnemyWallPositions[playerState.SelectedLane];
            paperController.PlayerType = playerState.PlayerType;
            paperController.UnitHP = playerState.UnitHP[UnitType.Paper];
            paperController.AttackDamage = playerState.UnitDamage[UnitType.Paper];
            BattleManager.Instance.UnitsOnField[playerState.PlayerType].Add(paperController);
        }
    }

    public void SpawnSizzors(int rewardAmount, PlayerState playerState) {
        for (int i = 0; i < rewardAmount; i++) {
            UnitController sizzorsController = Instantiate(SizzorsController,
                playerState.PlayerManager.MainSceneViewManagerPlayer.GetSpawnPoints()[playerState.SelectedLane]);
            sizzorsController.EnemyBasePosition = playerState.EnemyBasePosition;
            sizzorsController.EnemyWallPosition = playerState.EnemyWallPositions[playerState.SelectedLane];
            sizzorsController.PlayerType = playerState.PlayerType;
            sizzorsController.UnitHP = playerState.UnitHP[UnitType.Sizzors];
            sizzorsController.AttackDamage = playerState.UnitDamage[UnitType.Sizzors];
            BattleManager.Instance.UnitsOnField[playerState.PlayerType].Add(sizzorsController);
        }
    }
}