using UnityEngine;

public class ResourceManager : MonoBehaviour {
    private float ResourceUpdateTime = 2f;
    private float CurrentTime = 0.0f;
    private bool UpdateThisFram = false;

    public void UpdateTime() {
        UpdateThisFram = false;
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= ResourceUpdateTime) {
            CurrentTime %= ResourceUpdateTime;
            UpdateThisFram = true;
        }
    }

    public void UpdateResources(PlayerState playerState) {
        if (!UpdateThisFram) return;
        UpdatePlayerResources(playerState);
    }

    private void UpdatePlayerResources(PlayerState playerState) {
        playerState.ResourcesAmount[CurrencyType.War] += playerState.ResourcesIncome[CurrencyType.War];
        playerState.ResourcesAmount[CurrencyType.Defense] += playerState.ResourcesIncome[CurrencyType.Defense];
        playerState.ResourcesAmount[CurrencyType.Magic] += playerState.ResourcesIncome[CurrencyType.Magic];
        playerState.ResourcesAmount[CurrencyType.Unit] += playerState.ResourcesIncome[CurrencyType.Unit];
    }
}