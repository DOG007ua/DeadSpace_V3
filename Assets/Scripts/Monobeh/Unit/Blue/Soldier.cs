using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Soldier : Unit
{
    private void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        Initialize(this.gameObject);
        Team = TeamUnit.Blue;
        unitsInRange.Initialize(10, TeamUnit.Red);
        moveUnit = new MoveUnit(unitData.property.Speed, unitData.property.Heigth, transform);               
        UnitController = new BlueUnitController(this, moveUnit, selectUnit, unitsInRange, controllerTarget, weaponController);

        listComponents.Add(moveUnit);
        listComponents.Add(UnitController);
    }

    private void Update()
    {
        Execute();
    }
}