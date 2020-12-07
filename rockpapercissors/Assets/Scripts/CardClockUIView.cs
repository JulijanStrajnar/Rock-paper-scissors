using UnityEngine;
using UnityEngine.UI;

public class CardClockUIView : MonoBehaviour {
    [SerializeField] private Image Clock;

    public void UpdateUI(float percentageAmount, float updateTime) {
        Clock.fillAmount = MyMathUtils.Linear(percentageAmount, 0.0f, updateTime, 0.0f, 1.0f);
    }
}