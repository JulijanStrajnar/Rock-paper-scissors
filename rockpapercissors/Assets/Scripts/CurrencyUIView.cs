using TMPro;
using UnityEngine;

public class CurrencyUIView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI IncomeText;
    [SerializeField] private TextMeshProUGUI AmountText;

    public void UpdateUI(int income, int amount) {
        IncomeText.text = income.ToString();
        AmountText.text = amount.ToString();
    }
}