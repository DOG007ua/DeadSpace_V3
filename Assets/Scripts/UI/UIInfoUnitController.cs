using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfoUnitController : MonoBehaviour, IUIInfoUnitController
{
    private Unit selectUnit;
    [SerializeField] private GameObject classUnit;
    [SerializeField] private GameObject hpUnit;

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
