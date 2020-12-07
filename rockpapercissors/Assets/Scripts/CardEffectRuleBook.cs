using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PriceAndRewardCard {
    public int Price;
    public int Reward;

    public PriceAndRewardCard(int price, int reward) {
        Price = price;
        Reward = reward;
    }
}

public class CardEffectRuleBook {
    public Dictionary<int, PriceAndRewardCard> PlayerAmountToPrice;
    public CurrencyType PriceCurrencyType;
    public string EffectText;
    public System.Func<PlayerState, KeyValuePair<int, int>> GetPriceAndRewardFunction;

    public CardEffectRuleBook(Dictionary<int, PriceAndRewardCard> playerAmountToPrice, CurrencyType currencyType,
        string effectText
    ) {
        PlayerAmountToPrice = playerAmountToPrice;
        PriceCurrencyType = currencyType;
        EffectText = effectText;
    }

    public KeyValuePair<int, int> GetPriceAndRewardForIncome(PlayerState playerState) {
        PriceAndRewardCard value;

        if (PlayerAmountToPrice.TryGetValue(playerState.ResourcesIncome[PriceCurrencyType], out value)) {
            KeyValuePair<int, int> temp = new KeyValuePair<int, int>(value.Price,
                PlayerAmountToPrice[playerState.ResourcesIncome[PriceCurrencyType]].Reward);
            return temp;
        }

        KeyValuePair<int, int> temp2 = new KeyValuePair<int, int>(-1, -1);
        return temp2;
    }

    public KeyValuePair<int, int> GetPriceAndRewardForUnitHP(PlayerState playerState) {
        PriceAndRewardCard value;

        if (PlayerAmountToPrice.TryGetValue(playerState.UnitHP[UnitType.Rock], out value)) {
            KeyValuePair<int, int> temp = new KeyValuePair<int, int>(value.Price,
                PlayerAmountToPrice[playerState.UnitHP[UnitType.Rock]].Reward);
            return temp;
        }

        KeyValuePair<int, int> temp2 = new KeyValuePair<int, int>(-1, -1);
        return temp2;
    }

    public KeyValuePair<int, int> GetPriceAndRewardForBaseHP(PlayerState playerState) {
        int selectedEffect = Random.Range(0, PlayerAmountToPrice.Count);
        return new KeyValuePair<int, int>(PlayerAmountToPrice.ElementAt(selectedEffect).Value.Price,
            PlayerAmountToPrice.ElementAt(selectedEffect).Value.Reward);
    }

    public KeyValuePair<int, int> GetPriceAndRewardForWallHP(PlayerState playerState) {
        int selectedEffect = Random.Range(0, PlayerAmountToPrice.Count);
        return new KeyValuePair<int, int>(PlayerAmountToPrice.ElementAt(selectedEffect).Value.Price,
            PlayerAmountToPrice.ElementAt(selectedEffect).Value.Reward);
    }

    public KeyValuePair<int, int> GetPriceAndRewardForUnitAttack(PlayerState playerState) {
        PriceAndRewardCard value;

        if (PlayerAmountToPrice.TryGetValue(playerState.UnitDamage[UnitType.Rock], out value)) {
            KeyValuePair<int, int> temp = new KeyValuePair<int, int>(value.Price,
                PlayerAmountToPrice[playerState.UnitDamage[UnitType.Rock]].Reward);
            return temp;
        }

        KeyValuePair<int, int> temp2 = new KeyValuePair<int, int>(-1, -1);
        return temp2;
    }
}