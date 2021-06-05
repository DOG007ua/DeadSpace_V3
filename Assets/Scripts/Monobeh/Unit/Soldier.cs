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

    private void Initialize()
    {
        moveUnit = new MoveUnit(unitData.property.Speed, unitData.property.Heigth, transform);
        selectUnit = GetComponentInChildren<ISelectUnit>();
        listComponents.Add(moveUnit);
    }

    private void Update()
    {
        Execute();
    }
}