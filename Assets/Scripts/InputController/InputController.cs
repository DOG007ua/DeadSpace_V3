using Assets.Scripts.InputController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : IInputController
{
    private Unit selectedUnit;
    private IMove moveUnit;
    private ISelectUnit selectUnit;


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
        if(selectUnit != null) selectUnit.IsSelect = false;

        selectedUnit = unit;
        moveUnit = unit.moveUnit;
        selectUnit = unit.selectUnit;
        selectUnit.IsSelect = true;
    }

    private void MoveUnit(Vector3 position)
    {
        if(selectUnit != null)
        {
            moveUnit.MoveToPosition(position);
        }
    }

    private void SetTarget(Unit unit)
    {

    }
}
