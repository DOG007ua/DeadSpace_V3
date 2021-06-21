using Assets.Scripts.InputController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : IInputController
{
    private Unit selectedUnit;
    private IUnitController unitController;


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
        unitController = unit.UnitController;
        unitController.SelectUnit(false);

        selectedUnit = unit;
        unitController.SelectUnit(true);
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
