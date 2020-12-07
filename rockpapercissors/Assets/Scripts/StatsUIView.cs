using TMPro;
using UnityEngine;

public class StatsUIView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI AmountText;

    public void UpdateUI(int amount) {
        AmountText.text = amount.ToString();
    }
}