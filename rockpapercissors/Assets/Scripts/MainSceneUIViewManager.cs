using System.Collections.Generic;
using UnityEngine;

public class MainSceneUIViewManager : MonoBehaviour {
    [SerializeField] private CardClockUIView CardClockUIView;
    [SerializeField] private List<CardUIView> CardUIViews;
    [SerializeField] private CurrencyUIView WarCurrencyUIView;

    [SerializeField] private CurrencyUIView DefenseCurrencyUIView;

    //[SerializeField] private CurrencyUIView MagicCurrencyUIView;
    [SerializeField] private CurrencyUIView UnitCurrencyUIView;
    [SerializeField] private StatsUIView HPUIView;
    [SerializeField] private StatsUIView UnitDamageUIView;
    [SerializeField] private CardSelectionArrowUIView CardSelectionArrowUIView;

    public void UpdateUIView(PlayerState playerState) {
        CardClockUIView.UpdateUI(playerState.ClockTimer, playerState.CardUpdateTime);

        for (int i = 0; i < CardUIViews.Count; i++) {
            if (playerState.AvaliableCards.Count > i) {
                CardUIViews[i].gameObject.SetActive(true);
                CardUIViews[i].UpdateUI(playerState.AvaliableCards[i], playerState);
            }
            else {
                CardUIViews[i].gameObject.SetActive(false);
            }
        }

        WarCurrencyUIView.UpdateUI(playerState.ResourcesIncome[CurrencyType.War],
            playerState.ResourcesAmount[CurrencyType.War]);
        DefenseCurrencyUIView.UpdateUI(playerState.ResourcesIncome[CurrencyType.Defense],
            playerState.ResourcesAmount[CurrencyType.Defense]);
        // MagicCurrencyUIView.UpdateUI(playerState.ResourcesIncome[CurrencyType.Magic],
        //     playerState.ResourcesAmount[CurrencyType.Magic]);
        UnitCurrencyUIView.UpdateUI(playerState.ResourcesIncome[CurrencyType.Unit],
            playerState.ResourcesAmount[CurrencyType.Unit]);
        HPUIView.UpdateUI(playerState.UnitHP[UnitType.Rock]);
        UnitDamageUIView.UpdateUI(playerState.UnitDamage[UnitType.Rock]);

        CardSelectionArrowUIView.UpdateUI(CardUIViews[playerState.SelectedCard]);
    }
}