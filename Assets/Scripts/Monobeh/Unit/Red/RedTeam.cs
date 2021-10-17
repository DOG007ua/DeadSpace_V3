using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeam : Unit
{
    protected override void Initialize(GameObject gameObject)
    {
        base.Initialize(gameObject);
        Team = TeamUnit.Red;
        unitsInRange.Initialize(10, TeamUnit.Blue);
        moveUnit = new MoveUnit(inputUnitData.property.Speed, inputUnitData.property.Heigth, transform);
        UnitController = new RedUnitController(this, moveUnit, selectUnit, unitsInRange, controllerTarget);

        gameObject.AddComponent<UnitFeatureMonoRed>().Initialize(this);
        listComponents.Add(UnitController);
        listComponents.Add(moveUnit);
    }
}
