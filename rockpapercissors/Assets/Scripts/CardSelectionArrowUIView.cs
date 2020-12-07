using System;
using UnityEngine;

public class CardSelectionArrowUIView : MonoBehaviour {
    [SerializeField] private RectTransform CardSelectionTransform;

    public void UpdateUI(CardUIView cardUiView) {
        CardSelectionTransform.localPosition = new Vector3(cardUiView.GetTransformOfCard().localPosition.x,
            CardSelectionTransform.localPosition.y);
    }
}