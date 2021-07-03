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
        unitsInRange.Initialize(3, TeamUnit.Blue);
        moveUnit = new MoveUnit(unitData.property.Speed, unitData.property.Heigth, transform);
        listComponents.Add(moveUnit);

        UnitController = new RedUnitController(this, moveUnit, selectUnit, unitsInRange, controllerTarget);
    }

    private void Update()
    {
        Execute();
    }
}