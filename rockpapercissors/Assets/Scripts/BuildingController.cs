using UnityEngine;

public class BuildingController : MonoBehaviour {
    protected int ReferenceSize;
    protected PlayerState PlayerState;
    protected Transform BuldingTransform;
    protected Collider BuldingCollider;

    public virtual bool IsDestroyed() {
        return false;
    }

    private void Awake() {
        BuldingTransform = gameObject.transform;
        BuldingCollider = gameObject.GetComponent<Collider>();
    }

    public virtual void Init(PlayerState playerState) {
        PlayerState = playerState;
        gameObject.layer = (int) Mathf.Log(playerState.LayerMask.value, 2);
    }

    public virtual void AttackThisBuilding(int damage) {
    }
}