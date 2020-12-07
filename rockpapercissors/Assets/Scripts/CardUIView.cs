using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUIView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI PriceText;
    [SerializeField] private TextMeshProUGUI CurrencyTypeText;
    [SerializeField] private TextMeshProUGUI EffectText;
    [SerializeField] private RectTransform CardTransform;
    [SerializeField] private Image CardImage;

    public void UpdateUI(CardState cardState, PlayerState playerState) {
        PriceText.text = cardState.Price.ToString();
        CurrencyTypeText.text = cardState.CurrencyType.ToString();
        EffectText.text = cardState.EffectText + cardState.RewardAmount;
        if (!cardState.CanBeBought(playerState)) {
            CardImage.color = Color.gray;
        }
        else {
            CardImage.color = Color.white;
        }
    }

    public RectTransform GetTransformOfCard() {
        return CardTransform;
    }
}