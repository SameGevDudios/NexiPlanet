using UnityEngine;
using System.Collections.Generic;

public class BuildSelector : MonoBehaviour
{
    [SerializeField] private BuildPlacer _buildPlacer;
    [SerializeField] private List<GameObject> _buildingList;
    public void SelectBuilding(int index)
    {
        _buildPlacer.SetCurrentBuilding(_buildingList[index]);
    }
}
