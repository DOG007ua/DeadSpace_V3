using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIInfoUnitController
{
    void SetStaticValue();
    void SetNonFixedValue();
    void SelectUnit(Unit unit);
}
