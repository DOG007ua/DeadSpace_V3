using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInfoUnitController : MonoBehaviour, IUIInfoUnitController
{
    private UnitFeature selectUnit;
    [SerializeField] private TextMeshProUGUI classUnit = null;
    [SerializeField] private TextMeshProUGUI hpUnit = null;

    private void Start()
    {
        Reset();
    }

    public void SetNonFixedValue()
    {        
        hpUnit.text = Mathf.Round(selectUnit.Main.HP).ToString();
    }

    public void SetStaticValue()
    {
        classUnit.text = selectUnit.Main.Name;
    }

    public void SelectUnit(UnitFeature unit)
    {
        selectUnit = unit;
    }

    public void Reset()
    {
        hpUnit.text = string.Empty;
        classUnit.text = string.Empty;
    }
}
