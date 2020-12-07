using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManagerPlayer : MonoBehaviour {
    private InputMaster InputMaster;
    [NonSerialized] public FrameOfPlayerInput FrameOfPlayerInput;
    [SerializeField] private bool IsPlayerOne;

    public void Awake() {
        InputMaster = new InputMaster();
        FrameOfPlayerInput = new FrameOfPlayerInput();

        InputMaster.General.Esc.started += ctx => SceneManager.LoadScene("MainMenu");

        if (IsPlayerOne) {
            InputMaster.Player1.SelectCard.started += ctx =>
                FrameOfPlayerInput.SelectCard = ctx.ReadValue<float>();
            InputMaster.Player1.SelectCard.canceled += ctx => FrameOfPlayerInput.SelectCard = 0;

            InputMaster.Player1.SelectLane.started += ctx =>
                FrameOfPlayerInput.SelectLane = ctx.ReadValue<float>();
            InputMaster.Player1.SelectLane.canceled += ctx => FrameOfPlayerInput.SelectLane = 0;

            InputMaster.Player1.TryToBuy.started += ctx => FrameOfPlayerInput.TryToBuyCard = true;
            InputMaster.Player1.TryToBuy.canceled += ctx => FrameOfPlayerInput.TryToBuyCard = false;
        }
        else {
            InputMaster.Player2.SelectCard.started += ctx =>
                FrameOfPlayerInput.SelectCard = ctx.ReadValue<float>();
            InputMaster.Player2.SelectCard.canceled += ctx => FrameOfPlayerInput.SelectCard = 0;

            InputMaster.Player2.SelectLane.started += ctx =>
                FrameOfPlayerInput.SelectLane = ctx.ReadValue<float>();
            InputMaster.Player2.SelectLane.canceled += ctx => FrameOfPlayerInput.SelectLane = 0;

            InputMaster.Player2.TryToBuy.started += ctx => FrameOfPlayerInput.TryToBuyCard = true;
            InputMaster.Player2.TryToBuy.canceled += ctx => FrameOfPlayerInput.TryToBuyCard = false;
        }
    }

    private void OnEnable() {
        if (IsPlayerOne) {
            InputMaster.Player1.Enable();
        }
        else {
            InputMaster.Player2.Enable();
        }

        InputMaster.General.Enable();
    }

    private void OnDisable() {
        if (IsPlayerOne) {
            InputMaster.Player1.Disable();
        }
        else {
            InputMaster.Player2.Disable();
        }

        InputMaster.General.Disable();
    }
}