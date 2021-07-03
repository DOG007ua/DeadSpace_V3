using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class BlueUnitController : IUnitController
{
    public Unit Target => controllerTarget.Target;
    public Unit Unit { get; private set; }

    private IMove moveUnit;
    private ISelectUnit selectUnit;
    private IUnitsInRange unitsInRange;
    private IControlerTarget controllerTarget;
    private IWeaponController weaponController;
   

    public BlueUnitController(Unit unit,  IMove moveUnit, ISelectUnit selectUnit, IUnitsInRange unitsInRange, IControlerTarget controllerTarget, IWeaponController weaponController)
    {
        this.Unit = unit;
        this.moveUnit = moveUnit;
        this.selectUnit = selectUnit;
        this.unitsInRange = unitsInRange;
        this.controllerTarget = controllerTarget;
        this.weaponController = weaponController;

    }

    public void MoveToPosition(Vector3 position)
    {
        moveUnit.MoveToPosition(position);
    }

    public void SelectUnit(bool value)
    {
        selectUnit.IsSelect = value;
    }

    public void SetTarget(Unit target)
    {
        controllerTarget.SetTarget(target);
    }
}