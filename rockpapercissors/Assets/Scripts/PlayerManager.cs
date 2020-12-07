using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField] private MainSceneUIViewManager MainSceneUIManagerPlayer;
    [SerializeField] private InputManagerPlayer InputManagerPlayer;

    public MainSceneViewManager MainSceneViewManagerPlayer;

    public void Init(PlayerState playerState) {
        MainSceneViewManagerPlayer.Init(playerState);
    }

    public void UpdateView(PlayerState playerState) {
        MainSceneUIManagerPlayer.UpdateUIView(playerState);
        MainSceneViewManagerPlayer.UpdateView(playerState);
    }

    public FrameOfPlayerInput GetInputsThisFrame() {
        return InputManagerPlayer.FrameOfPlayerInput;
    }
}