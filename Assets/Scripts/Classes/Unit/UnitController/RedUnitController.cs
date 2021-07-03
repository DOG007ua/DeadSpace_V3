using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class RedUnitController : IUnitController
{
    public Unit Target { get; private set; }

    public Unit Unit { get; private set; }

    private IMove moveUnit;
    private ISelectUnit selectUnit;
    private IUnitsInRange unitsInRange;
    private IControlerTarget controllerTarget;

    public RedUnitController(Unit unit, IMove moveUnit, ISelectUnit selectUnit, IUnitsInRange unitsInRange, IControlerTarget controllerTarget)
    {
        this.Unit = unit;
        this.moveUnit = moveUnit;
        this.selectUnit = selectUnit;
        this.unitsInRange = unitsInRange;
        this.controllerTarget = controllerTarget;
    }

    public void MoveToPosition(Vector3 position)
    {
        moveUnit.MoveToPosition(position);
    }

    public void SelectUnit(bool value)
    {
        throw new NotImplementedException();
    }

    public void SetTarget(Unit target)
    {
        controllerTarget.SetTarget(target);
    }
}