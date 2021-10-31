using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPosition : MonoBehaviour
{
    public Vector3 position;
    public Vector2 direction;
    public float X;
    public float Y;

    public RectTransform arrow;


    private bool isVisiblePreviusScreen;
    private float radius = 200;
    private Vector2 centerScreen;

    private bool IsVisibleNow
    {
        get => isVisiblePreviusScreen;
        set 
        {
            if(isVisiblePreviusScreen != value)
            {
                arrow.gameObject.SetActive(!value);
            }
            isVisiblePreviusScreen = value;
        }
    }
    void Start()
    {
        arrow.gameObject.SetActive(false);
        centerScreen = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        position = Camera.main.WorldToScreenPoint(transform.position);
        var visible = IsVisible(position);
        /*if (!visible)
        {
            PositionArrow(position);
        }*/
        PositionArrow(position);
        IsVisibleNow = visible;
    }

    private bool IsVisible(Vector3 position)
    {
        if ((position.x > 0 && position.x < Screen.width) &&
            (position.y > 0 && position.y < Screen.height))
            return true;
        else
            return false;
    }

    private void PositionArrow(Vector3 selectUnit)
    {
        var positionUnit = new Vector2(selectUnit.x, selectUnit.y);
        direction = (centerScreen - positionUnit).normalized;
        var x = radius * direction.x;
        var y = radius * direction.y;
        arrow.localPosition = new Vector3(-x, -y, 0);
    }
}
