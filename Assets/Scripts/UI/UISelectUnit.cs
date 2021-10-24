using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectUnit : MonoBehaviour
{
    public bool IsSelectUnitUI { get; set; }
    private Unit selectUnit;
    private IUIInfoUnitController uiInfoUnit;
    private IUIInfoGunController uiInfoGun;

    public void SelectUnit(Unit unit)
    {
        selectUnit = unit;
        IsSelectUnitUI = unit == null ? false : true;
        uiInfoUnit.SelectUnit(unit);
        uiInfoGun.SelectUnit(unit);
        SetStaticValue();
    }

    private void Start()
    {
        uiInfoUnit = GetComponent<IUIInfoUnitController>();
        uiInfoGun = GetComponent<IUIInfoGunController>();
    }

    private void Update()
    {
        if (!IsSelectUnitUI) return;

        SetNonFixedValue();
    }

    private void SetStaticValue()
    {
        uiInfoUnit.SetStaticValue();
        uiInfoGun.SetStaticValue();
    }

    private void SetNonFixedValue()
    {
        uiInfoUnit.SetNonFixedValue();
        uiInfoGun.SetNonFixedValue();
    }
}
