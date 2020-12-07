using UnityEngine;

public class LaneSelectionArrowView : MonoBehaviour {
    private Transform LaneSelectionArrowTransform;
    private Material Material;

    public void Init(PlayerState playerState) {
        if (playerState.PlayerType == PlayerType.PlayerOne) {
            Material.color = Color.green;
        }
        else {
            Material.color = Color.red;
        }
    }

    private void Awake() {
        LaneSelectionArrowTransform = GetComponent<Transform>();
        Material = GetComponent<MeshRenderer>().material;
    }

    public void UpdateView(Transform cardUiView) {
        LaneSelectionArrowTransform.localPosition = new Vector3(LaneSelectionArrowTransform.localPosition.x,
            LaneSelectionArrowTransform.localPosition.y, cardUiView.localPosition.z);
    }
}