using System;

public class CardState {
    public int Price;
    public int RewardAmount;
    public CurrencyType CurrencyType;
    public Action<int, PlayerState> EffectFunctionDelegate;
    public String EffectText;
    public bool CanBeUsed;
    public CardEffectRuleBook CardEffectRuleBook;

    public CardState(int price, int rewardAmount, CurrencyType currencyType,
        Action<int, PlayerState> effectFunction, string effectText, CardEffectRuleBook cardEffectRuleBook,
        bool canBeUsed = true) {
        Price = price;
        RewardAmount = rewardAmount;
        CurrencyType = currencyType;
        EffectFunctionDelegate = effectFunction;
        EffectText = effectText;
        CanBeUsed = canBeUsed;
        CardEffectRuleBook = cardEffectRuleBook;
    }

    public bool CanBeBought(PlayerState playerState) {
        if (playerState.ResourcesAmount[CurrencyType] >= Price) {
            return true;
        }

        else return false;
    }
}