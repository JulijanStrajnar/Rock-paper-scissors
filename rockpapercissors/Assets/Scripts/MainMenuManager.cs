using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    public Button StartGame;
    public Button ExitGame;
    public TextMeshProUGUI PlayerThatWon;

    private void Awake() {
        PlayerThatWon.text = BattleManager.Instance.WonPlayer.ToString() + " Won";
        StartGame.onClick.AddListener(StartGameFunction);
        ExitGame.onClick.AddListener(ExitGameFunction);
    }

    public void StartGameFunction() {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGameFunction() {
        Application.Quit();
    }
}