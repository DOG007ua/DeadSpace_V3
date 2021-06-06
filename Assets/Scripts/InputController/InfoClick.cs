using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoClick
{
    public Vector3 PositionClick;
    public GameObject GameObjectClick;
    public Unit Unit;

    public InfoClick(Vector3 positionClick, GameObject gameObjectClick, Unit unit)
    {
        PositionClick = positionClick;
        GameObjectClick = gameObjectClick;
        Unit = unit;
    }
}
