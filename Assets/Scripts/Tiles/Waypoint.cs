using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; }}

    bool isSelected = false;

    private void OnMouseDown()
    {
        if (isPlaceable && isSelected)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }

    public void SetTower(Tower NewTowerPrefab)
    {
        towerPrefab = NewTowerPrefab;
    }

    public void ChangeIsSelected(bool _isSelected)
    {
        isSelected = _isSelected;
    }
}
