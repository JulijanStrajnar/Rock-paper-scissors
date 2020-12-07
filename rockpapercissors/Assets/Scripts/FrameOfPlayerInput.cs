using UnityEngine;

public class FrameOfPlayerInput : MonoBehaviour {
    public float SelectCard;
    public float SelectLane;
    public bool TryToBuyCard;

    public void ClearInput() {
        SelectCard = 0;
        SelectLane = 0;
        TryToBuyCard = false;
    }
}