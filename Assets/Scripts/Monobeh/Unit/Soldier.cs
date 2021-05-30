using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Soldier : Unit
{
    private void Start()
    {
        Initialzie();
    }

    private void Initialzie()
    {
        moveUnit = new MoveUnit(unitData.property.Speed, unitData.property.Heigth, transform);
        selectUnit = new SelectUnit();
        listComponents.Add(moveUnit);
    }

    private void Update()
    {
        Execute();
    }
}