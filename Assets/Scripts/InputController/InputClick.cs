using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputClick : MonoBehaviour
{
    public event Action<InfoClick> EventClickRight;
    public event Action<InfoClick> EventClickLeft;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickMouse();
    }

    private void ClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var info = Click();
            EventClickLeft?.Invoke(info);
        }
        if (Input.GetMouseButtonDown(1))
        {
            var info = Click();
            EventClickRight?.Invoke(info);
        }
    }

    private InfoClick Click()
    {
        var hit = GetHit();
        var position = PositionClick(hit);
        var go = GameObjectClick(hit);
        var info = new InfoClick(position, go, go.GetComponent<Unit>());
        Debug.Log($"Position: {info.PositionClick}");
        Debug.Log($"GameObject: {info.GameObjectClick}");
        Debug.Log($"Unit: {info.Unit}");
        return info;
    }

    private Vector3 PositionClick(RaycastHit hit)
    {
        return hit.point;
    }

    private RaycastHit GetHit()
    {
        Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 position = Vector3.zero;

        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            
        }
        return hit;
    }

    private GameObject GameObjectClick(RaycastHit hit)
    {
        if (hit.transform.gameObject.tag == "Terrain") return null;
        return hit.transform.gameObject;
    }
}
