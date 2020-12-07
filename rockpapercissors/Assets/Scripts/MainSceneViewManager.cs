using System.Collections.Generic;
using UnityEngine;

public class MainSceneViewManager : MonoBehaviour {
    public BaseView BaseView;
    public WallView WallView;
    [SerializeField] private LaneSelectionArrowView LaneSelectionArrowView;
    [SerializeField] private List<Transform> SpawnPoints;
    [SerializeField] private List<Transform> WallPositions;
    public Transform BaseFinishPoint;

    public List<Transform> GetSpawnPoints() {
        return SpawnPoints;
    }

    public List<Vector3> GetWallPositions() {
        List<Vector3> positions = new List<Vector3>();
        foreach (var wallPosition in WallPositions) {
            positions.Add(wallPosition.position);
        }

        return positions;
    }

    public void Init(PlayerState playerState) {
        BaseView.Init(playerState);
        WallView.Init(playerState);
        LaneSelectionArrowView.Init(playerState);
    }


    public void UpdateView(PlayerState playerState) {
        BaseView.UpdateView();
        WallView.UpdateView();
        LaneSelectionArrowView.UpdateView(SpawnPoints[playerState.SelectedLane]);
    }
}