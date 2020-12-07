using System.Collections.Generic;
using UnityEngine;

public class BattleManager {

    public static void ResetBattleManager() {
        instance = null;
    }
    //Private Constructor.  
    private BattleManager() {
    }
    private static BattleManager instance = null;
    public static BattleManager Instance {
        get {
            if (instance == null) {
                instance = new BattleManager();
            }
            return instance;
        }
    }

    public PlayerType WonPlayer = PlayerType.None;

    public Dictionary<PlayerType, List<UnitController>> UnitsOnField =
        new Dictionary<PlayerType, List<UnitController>>();

    public Dictionary<PlayerType, List<BuildingController>> BuildingsOnfield =
        new Dictionary<PlayerType, List<BuildingController>>();

    public Dictionary<PlayerType, LayerMask> EnemyBuildingLayerMask =
        new Dictionary<PlayerType, LayerMask>();

    public Dictionary<UnitType, UnitType> UnitTypeToUnitTypeBonus = new Dictionary<UnitType, UnitType>() {
        {UnitType.Paper, UnitType.Rock},
        {UnitType.Rock, UnitType.Sizzors},
        {UnitType.Sizzors, UnitType.Paper},
    };

    public Dictionary<PlayerType, Color> PlayerColors = new Dictionary<PlayerType, Color>() {
        {PlayerType.PlayerOne, Color.green},
        {PlayerType.PlayerTwo, Color.red},
    };
}