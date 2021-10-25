using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIInfoGunController
{
    void SetStaticValue();
    void SetNonFixedValue();
    void SelectUnit(UnitFeature unit);
    void Reset();
}
