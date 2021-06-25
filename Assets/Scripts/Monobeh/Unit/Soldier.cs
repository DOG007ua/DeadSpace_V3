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
        unitsInRange.Initialize(3, TeamUnit.Blue);
        moveUnit = new MoveUnit(unitData.property.Speed, unitData.property.Heigth, transform);
        weaponController = new WeaponController();

        listComponents.Add(moveUnit);
        InitUnitController();
    }

    private void Update()
    {
        Execute();
    }
}