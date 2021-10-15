using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Beiling : RedTeam
{
    private void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        Initialize(this.gameObject);        
        UnitController = new RedUnitController(this, moveUnit, selectUnit, unitsInRange, controllerTarget);

        
        listComponents.Add(UnitController);
    }

    private void Update()
    {
        Execute();
    }
}