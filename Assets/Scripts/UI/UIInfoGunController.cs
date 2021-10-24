using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfoGunController : MonoBehaviour, IUIInfoGunController
{
    private Unit selectUnit;
    [SerializeField] private GameObject ammoNow;
    [SerializeField] private GameObject ammoMax;
    [SerializeField] private GameObject gunName;

    public void SetNonFixedValue()
    {

    }

    public void SetStaticValue()
    {

    }


    public void SelectUnit(Unit unit)
    {
        selectUnit = unit;
    }
}
