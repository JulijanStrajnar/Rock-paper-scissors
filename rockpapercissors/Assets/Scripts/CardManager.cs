using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour {
    private SpawnManager SpawnManager;

    private Dictionary<Action<int, PlayerState>, CardEffectRuleBook> ListOfEffects =
        new Dictionary<Action<int, PlayerState>, CardEffectRuleBook>();

    // private CardEffectRuleBook BuildingWallRuleBook =
    //   new CardEffectRuleBook(new KeyValuePair<int, int>(5, 50), 0.5f, CurrencyType.Defense, "Build wall HP");

    //private CardEffectRuleBook BuildingBaseRuleBook =
    // new CardEffectRuleBook(new KeyValuePair<int, int>(5, 50), 0.5f, CurrencyType.Defense, "Build base HP");

    private CardEffectRuleBook WarResourceRuleBook =
        new CardEffectRuleBook(new Dictionary<int, PriceAndRewardCard>() {
            {1, new PriceAndRewardCard(10, 1)},
            {2, new PriceAndRewardCard(30, 1)},
            {3, new PriceAndRewardCard(90, 1)},
            {4, new PriceAndRewardCard(180, 1)},
        }, CurrencyType.War, "Increase war income by ");

    private CardEffectRuleBook DefenseResourceRuleBook =
        new CardEffectRuleBook(new Dictionary<int, PriceAndRewardCard>() {
            {1, new PriceAndRewardCard(10, 1)},
            {2, new PriceAndRewardCard(30, 1)},
            {3, new PriceAndRewardCard(90, 1)},
            {4, new PriceAndRewardCard(180, 1)},
        }, CurrencyType.Defense, "Increase defense income by ");

    private CardEffectRuleBook UnitResourceRuleBook =
        new CardEffectRuleBook(new Dictionary<int, PriceAndRewardCard>() {
            {1, new PriceAndRewardCard(10, 1)},
            {2, new PriceAndRewardCard(30, 1)},
            {3, new PriceAndRewardCard(90, 1)},
            {4, new PriceAndRewardCard(180, 1)},
        }, CurrencyType.Unit, "Increase unit income by ");

    private CardEffectRuleBook UnitAttackRuleBook =
        new CardEffectRuleBook(new Dictionary<int, PriceAndRewardCard>() {
            {30, new PriceAndRewardCard(10, 5)},
            {35, new PriceAndRewardCard(30, 10)},
            {45, new PriceAndRewardCard(90, 20)},
            {65, new PriceAndRewardCard(180, 40)},
        }, CurrencyType.War, "Increase all unit attack by ");

    private CardEffectRuleBook UnitHPRuleBook =
        new CardEffectRuleBook(new Dictionary<int, PriceAndRewardCard>() {
            {100, new PriceAndRewardCard(10, 10)},
            {110, new PriceAndRewardCard(30, 20)},
            {130, new PriceAndRewardCard(90, 40)},
            {170, new PriceAndRewardCard(180, 80)},
        }, CurrencyType.War, "Increase all unit HP by ");

    private CardEffectRuleBook BaseHP =
        new CardEffectRuleBook(new Dictionary<int, PriceAndRewardCard>() {
            {-1, new PriceAndRewardCard(20, 100)},
            {-2, new PriceAndRewardCard(40, 200)},
            {-3, new PriceAndRewardCard(80, 400)},
            {-4, new PriceAndRewardCard(120, 600)},
            {-5, new PriceAndRewardCard(160, 800)},
        }, CurrencyType.Defense, "Increase base HP by ");

    private CardEffectRuleBook WallRuleBook =
        new CardEffectRuleBook(new Dictionary<int, PriceAndRewardCard>() {
            {-1, new PriceAndRewardCard(10, 100)},
            {-2, new PriceAndRewardCard(20, 200)},
            {-3, new PriceAndRewardCard(40, 400)},
            {-4, new PriceAndRewardCard(60, 600)},
            {-5, new PriceAndRewardCard(80, 800)},
        }, CurrencyType.Defense, "Inrease wall HP by ");

    //private CardEffectRuleBook MagicResourceRuleBook =
    //    new CardEffectRuleBook(new KeyValuePair<int, int>(1, 3), 20f, CurrencyType.Magic, "Increase magic income");

    public void Init(SpawnManager spawnManager) {
        SpawnManager = spawnManager;

        // add all random card effect functions
        // ListOfEffects.Add(IncreaseBaseHP, BuildingBaseRuleBook);
        // ListOfEffects.Add(IncreaseWallHP, BuildingWallRuleBook);

        //ListOfEffects.Add(IncreaseMagicIncome, MagicResourceRuleBook);
        WarResourceRuleBook.GetPriceAndRewardFunction = WarResourceRuleBook.GetPriceAndRewardForIncome;
        DefenseResourceRuleBook.GetPriceAndRewardFunction = DefenseResourceRuleBook.GetPriceAndRewardForIncome;
        UnitResourceRuleBook.GetPriceAndRewardFunction = UnitResourceRuleBook.GetPriceAndRewardForIncome;
        UnitAttackRuleBook.GetPriceAndRewardFunction = UnitAttackRuleBook.GetPriceAndRewardForUnitAttack;
        UnitHPRuleBook.GetPriceAndRewardFunction = UnitHPRuleBook.GetPriceAndRewardForUnitHP;
        BaseHP.GetPriceAndRewardFunction = BaseHP.GetPriceAndRewardForBaseHP;
        WallRuleBook.GetPriceAndRewardFunction = WallRuleBook.GetPriceAndRewardForWallHP;

        ListOfEffects.Add(IncreaseWarIncome, WarResourceRuleBook);
        ListOfEffects.Add(IncreaseDefenseIncome, DefenseResourceRuleBook);
        ListOfEffects.Add(IncreaseUnitIncome, UnitResourceRuleBook);
        ListOfEffects.Add(IncreaseUnitAttack, UnitAttackRuleBook);
        ListOfEffects.Add(IncreaseUnitHp, UnitHPRuleBook);
        ListOfEffects.Add(IncreaseBaseHP, BaseHP);
        ListOfEffects.Add(IncreaseWallHP, WallRuleBook);
    }

    public List<CardState> UpdateCards(PlayerState playerState, bool forceUpdate = false) {
        playerState.ClockTimer += Time.deltaTime;
        if (playerState.ClockTimer >= playerState.CardUpdateTime || forceUpdate) {
            playerState.ClockTimer = 0.0f;
            List<CardState> newCards = new List<CardState>();
            newCards.AddRange(CreateRandomCards(playerState));
            newCards.AddRange(CreateBasicCards());
            return newCards;
        }

        return null;
    }

    private List<CardState> CreateRandomCards(PlayerState playerState) {
        List<CardState> cardStates = new List<CardState>();
        Dictionary<Action<int, PlayerState>, CardEffectRuleBook> avaliableEffects =
            new Dictionary<Action<int, PlayerState>, CardEffectRuleBook>();

        for (int i = 0; i < ListOfEffects.Count; i++) {
            int price = ListOfEffects.ElementAt(i).Value.GetPriceAndRewardFunction(playerState).Key;
            if (price >= 0) {
                avaliableEffects.Add(ListOfEffects.ElementAt(i).Key, ListOfEffects.ElementAt(i).Value);
            }
        }

        int count = avaliableEffects.Count;
        if (count > 3) count = 3;

        for (int i = 0; i < count; i++) {
            int selectedEffect = Random.Range(0, avaliableEffects.Count);
            CardEffectRuleBook cardEffectRuleBook = avaliableEffects.ElementAt(selectedEffect).Value;

            KeyValuePair<int, int> priceAndReward = cardEffectRuleBook.GetPriceAndRewardFunction(playerState);

            cardStates.Add(new CardState(priceAndReward.Key, priceAndReward.Value, cardEffectRuleBook.PriceCurrencyType,
                avaliableEffects.ElementAt(selectedEffect).Key, cardEffectRuleBook.EffectText, cardEffectRuleBook));

            avaliableEffects.Remove(avaliableEffects.ElementAt(selectedEffect).Key);
        }

        return cardStates;
    }

    private List<CardState> CreateBasicCards() {
        List<CardState> cardStates = new List<CardState>();
        cardStates.Add(new CardState(5, 1, CurrencyType.Unit, SpawnManager.SpawnRock, "Spawn rock", null, false));
        cardStates.Add(new CardState(5, 1, CurrencyType.Unit, SpawnManager.SpawnPaper, "Spawn paper", null, false));
        cardStates.Add(new CardState(5, 1, CurrencyType.Unit, SpawnManager.SpawnSizzors, "Spawn sizzors", null, false));
        return cardStates;
    }

    private void IncreaseBaseHP(int rewardAmount, PlayerState playerState) {
        playerState.BaseHP += rewardAmount;
    }

    private void IncreaseWallHP(int rewardAmount, PlayerState playerState) {
        playerState.WallHP += rewardAmount;
    }

    private void IncreaseWarIncome(int rewardAmount, PlayerState playerState) {
        playerState.ResourcesIncome[CurrencyType.War] += rewardAmount;
    }

    private void IncreaseDefenseIncome(int rewardAmount, PlayerState playerState) {
        playerState.ResourcesIncome[CurrencyType.Defense] += rewardAmount;
    }

    private void IncreaseMagicIncome(int rewardAmount, PlayerState playerState) {
        playerState.ResourcesIncome[CurrencyType.Magic] += rewardAmount;
    }

    private void IncreaseUnitIncome(int rewardAmount, PlayerState playerState) {
        playerState.ResourcesIncome[CurrencyType.Unit] += rewardAmount;
    }

    private void IncreaseUnitAttack(int rewardAmount, PlayerState playerState) {
        var keys = new List<UnitType>(playerState.UnitDamage.Keys);
        foreach (UnitType key in keys) {
            playerState.UnitDamage[key] += rewardAmount;
        }

        foreach (var unitOnField in BattleManager.Instance.UnitsOnField[playerState.PlayerType]) {
            unitOnField.AttackDamage += rewardAmount;
        }
    }

    private void IncreaseUnitHp(int rewardAmount, PlayerState playerState) {
        var keys = new List<UnitType>(playerState.UnitHP.Keys);
        foreach (UnitType key in keys) {
            playerState.UnitHP[key] += rewardAmount;
        }

        foreach (var unitOnField in BattleManager.Instance.UnitsOnField[playerState.PlayerType]) {
            unitOnField.UnitHP += rewardAmount;
        }
    }

    public void TryToBuyCard(PlayerState playerState) {
        if (!playerState.TryToBuyCard) return;
        playerState.TryToBuyCard = false;

        CardState selectedCard = playerState.AvaliableCards[playerState.SelectedCard];
        if (playerState.ResourcesAmount[selectedCard.CurrencyType] - selectedCard.Price >= 0) {
            playerState.ResourcesAmount[selectedCard.CurrencyType] -= selectedCard.Price;
            selectedCard.EffectFunctionDelegate(selectedCard.RewardAmount, playerState);
            if (selectedCard.CanBeUsed) {
                playerState.AvaliableCards.Remove(selectedCard);
            }
        }
    }
}