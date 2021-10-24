using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInfoGunController : MonoBehaviour, IUIInfoGunController
{
    private UnitFeature selectUnit;
    [SerializeField] private TextMeshProUGUI ammoNow = null;
    [SerializeField] private TextMeshProUGUI ammoMax = null;
    [SerializeField] private TextMeshProUGUI gunName = null;

    private void Start()
    {
        Reset();
    }

    public void SetNonFixedValue()
    {
        ammoNow.text = $"{selectUnit.Gun.AmmoInShop}/{selectUnit.Gun.MaxInShop}";
    }

    public void SetStaticValue()
    {
        gunName.text = selectUnit.Gun.Name;
        ammoMax.text = "180";
    }

    public void SelectUnit(UnitFeature unit)
    {
        selectUnit = unit;
    }

    public void Reset()
    {
        ammoNow.text = string.Empty;
        gunName.text = string.Empty;
    }
}
