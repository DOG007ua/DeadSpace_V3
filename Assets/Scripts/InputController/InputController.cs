using System;
using UnityEngine;

public class InputController : IInputController
{
    private Unit selectedUnit;
    private IUnitController unitController;

    public event Action<Unit> eventSelectUnit;

    public void ReactionLeftClick(InfoClick info)
    {
        if(info.Unit != null)
        {
            SelectUnit(info.Unit);
        }
    }

    public void ReactionRightClick(InfoClick info)
    {
        if(selectedUnit != null)
        {
            MoveUnit(info.PositionClick);
        }
    }

    private void SelectUnit(Unit unit)
    {
        if (unit == selectedUnit) return;
        if (unit.Team == TeamUnit.Red) return;
        if (unitController != null) unitController.SelectUnit(false);

        unitController = unit.UnitController;
        selectedUnit = unit;
        unitController.SelectUnit(true);

        eventSelectUnit?.Invoke(unit);
    }

    private void MoveUnit(Vector3 position)
    {
        if(selectedUnit != null)
        {
            unitController.MoveToPosition(position);
        }
    }

    private void SetTarget(Unit unit)
    {
        unitController.SetTarget(unit);
    }
}
