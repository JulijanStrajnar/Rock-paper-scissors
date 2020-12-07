using UnityEngine;

public class WallView : BuildingController {
    public override void Init(PlayerState playerState) {
        base.Init(playerState);

        ReferenceSize = playerState.WallHP;
    }

    public override bool IsDestroyed() {
        return PlayerState.WallHP <= 0;
    }

    public void UpdateView() {
        bool updatenavMesh = false;
        float yScale = (float) PlayerState.WallHP / ReferenceSize;
        bool wallBuildFromNothing = yScale > 0 && BuldingTransform.localScale.y <= 0;
        bool wallDestroyed = yScale <= 0 && BuldingTransform.localScale.y > 0;
        if (wallBuildFromNothing || wallDestroyed) {
            updatenavMesh = true;
        }

        if (wallBuildFromNothing) {
            BuldingCollider.enabled = true;
        }

        BuldingTransform.localScale = new Vector3(BuldingTransform.localScale.x, yScale, BuldingTransform.localScale.z);
        if (updatenavMesh) {
            NavMeshSurfaceManager.NavMeshSurface.BuildNavMesh();
        }
    }

    public override void AttackThisBuilding(int damage) {
        PlayerState.WallHP -= damage;
        if (PlayerState.WallHP < 0) {
            PlayerState.WallHP = 0;
            BuldingCollider.enabled = false;
        }
    }
}