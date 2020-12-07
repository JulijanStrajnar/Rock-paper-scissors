using System.Collections.Generic;
using UnityEngine;

public class PlayerState {
    public PlayerType PlayerType;

    public int BaseHP = 500;
    public int WallHP = 200;

    public Dictionary<CurrencyType, int> ResourcesAmount = new Dictionary<CurrencyType, int>() {
        {CurrencyType.War, 0},
        {CurrencyType.Defense, 0},
        {CurrencyType.Magic, 0},
        {CurrencyType.Unit, 0}
    };

    public Dictionary<CurrencyType, int> ResourcesIncome = new Dictionary<CurrencyType, int>() {
        {CurrencyType.War, 1},
        {CurrencyType.Defense, 1},
        {CurrencyType.Magic, 1},
        {CurrencyType.Unit, 1}
    };

    public Dictionary<UnitType, int> UnitDamage = new Dictionary<UnitType, int>() {
        {UnitType.Rock, 30},
        {UnitType.Paper, 30},
        {UnitType.Sizzors, 30},
    };

    public Dictionary<UnitType, int> UnitHP = new Dictionary<UnitType, int>() {
        {UnitType.Rock, 100},
        {UnitType.Paper, 100},
        {UnitType.Sizzors, 100},
    };

    public List<CardState> AvaliableCards = new List<CardState>();

    private const int LaneCount = 3;

    public float ClockTimer = 0.0f;
    public float CardUpdateTime = 30.0f;

    public int SelectedLane = 1;
    public int SelectedCard = 0;

    public bool TryToBuyCard = false;

    public PlayerManager PlayerManager;
    public Vector3 EnemyBasePosition;
    public List<Vector3> EnemyWallPositions;

    public LayerMask LayerMask = new LayerMask();

    public void UpdateCards(List<CardState> cardStates) {
        if (cardStates == null) return;

        AvaliableCards = cardStates;
    }

    public void UpdatePlayerStateBasedOnPlayerInput(FrameOfPlayerInput frameOfPlayerInput) {
        TryToBuyCard = frameOfPlayerInput.TryToBuyCard;
        int selectedLane = (int) frameOfPlayerInput.SelectLane;
        int selectedCard = (int) frameOfPlayerInput.SelectCard;

        if (selectedLane == -1 && SelectedLane == 0) {
            SelectedLane = LaneCount - 1;
        }
        else {
            SelectedLane += (int) frameOfPlayerInput.SelectLane;
            if (SelectedLane == LaneCount) {
                SelectedLane = 0;
            }
        }

        if (selectedCard == -1 && SelectedCard == 0) {
            SelectedCard = AvaliableCards.Count - 1;
        }
        else {
            SelectedCard += (int) frameOfPlayerInput.SelectCard;

            if (SelectedCard == AvaliableCards.Count) {
                SelectedCard = 0;
            }
        }

        frameOfPlayerInput.ClearInput();
    }
}