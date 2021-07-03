using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Beiling : Unit
{
    private void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        Initialize(this.gameObject);
        Team = TeamUnit.Red;
        unitsInRange.Initialize(10, TeamUnit.Blue);
        moveUnit = new MoveUnit(unitData.property.Speed, unitData.property.Heigth, transform);
        UnitController = new RedUnitController(this, moveUnit, selectUnit, unitsInRange, controllerTarget);

        listComponents.Add(moveUnit);
        listComponents.Add(UnitController);
    }

    private void Update()
    {
        Execute();
    }
}