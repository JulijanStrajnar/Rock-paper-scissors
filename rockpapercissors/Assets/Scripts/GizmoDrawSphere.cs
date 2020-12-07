using UnityEngine;

public class GizmoDrawSphere : MonoBehaviour {
    public float Size;
    public Color Color;
    public float Alpha = 0.35f;

    private void OnDrawGizmos() {
        Gizmos.color = new Color(Color.r, Color.g, Color.b, Alpha);
        Gizmos.DrawSphere(transform.position, Size);
    }
}