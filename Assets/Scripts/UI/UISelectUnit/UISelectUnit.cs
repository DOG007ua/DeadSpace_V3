using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectUnit : MonoBehaviour
{
    public bool IsSelectUnitUI { get; set; }
    private UnitFeature selectUnitFeature;
    private IUIInfoUnitController uiInfoUnit;
    private IUIInfoGunController uiInfoGun;

    public void SelectUnit(Unit unit)
    {
        selectUnitFeature = unit.UnitFeature;
        IsSelectUnitUI = unit == null ? false : true;
        uiInfoUnit.SelectUnit(selectUnitFeature);
        uiInfoGun.SelectUnit(selectUnitFeature);
        SetStaticValue();
    }

    private void Start()
    {
        uiInfoUnit = GetComponentInChildren<IUIInfoUnitController>();
        uiInfoGun = GetComponentInChildren<IUIInfoGunController>();
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
