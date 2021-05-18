using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Tower tower;

    Waypoint[] waypoints;
    bool isSelected = false;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeButtonColor();
    }

    private void ChangeButtonColor()
    {
        Color imageColor;
        if (!isSelected)
        {
            imageColor = img.color;
            imageColor.a = 0.3f;
        }
        else
        {
            imageColor = img.color;
            imageColor.a = 1f;
        }

        img.color = imageColor;
    }

    public void SetEnemiesOnWaypoints()
    {
        ButtonController[] buttons = FindObjectsOfType<ButtonController>();
        foreach (ButtonController button in buttons)
        {
            if (button.gameObject != this.gameObject)
            {
                button.SetIsSelected(false);
            }
        }
        isSelected = !isSelected;
        waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            waypoint.SetTower(tower);
            waypoint.ChangeIsSelected(isSelected);
        }
    }

    public void SetIsSelected(bool a)
    {
        isSelected = a;
    }
}
