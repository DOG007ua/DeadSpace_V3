using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlueTeam : Unit
{
    protected override void Initialize(GameObject gameObject)
    {
        base.Initialize(gameObject);
        Team = TeamUnit.Blue;
        unitsInRange.Initialize(10, TeamUnit.Red);
        moveUnit = new MoveUnit(inputUnitData.property.Speed, inputUnitData.property.Heigth, transform);
        UnitController = new BlueUnitController(this, moveUnit, selectUnit, unitsInRange, controllerTarget, weaponController);

        gameObject.AddComponent<UnitFeatureMonoBlue>().Initialize(UnitFeature);
        listComponents.Add(UnitController);
        listComponents.Add(moveUnit);
    }
}