using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SelectTargetInRange : IControlerTarget
{
    private Unit target;
    private Transform transformUnit;

    public Unit Target
    {
        get => target;
        private set
        {
            target = value;
            if(target == null)
            {
                FindNewUnit();
            }
            if(Target == null) Debug.LogWarning($"Target NULL, Unit: {transformUnit.name}");
            else Debug.LogWarning($"Target: {Target.transform.name}, Unit: {transformUnit.name}");
        }
    }
    private IUnitsInRange unitsInRange;

    public SelectTargetInRange(IUnitsInRange unitsInRange, Transform transformUnit)
    {
        this.unitsInRange = unitsInRange;
        this.transformUnit = transformUnit;

        unitsInRange.AddUnit += AddUnitInRange;
        unitsInRange.RemoveUnit += RemoveUnitInRange;

        FindNewUnit();
    }


    public void SetTarget(Unit unit)
    {        
        Target = unit;
        if(Target == null)
        {
            FindNewUnit();
        }
    }

    private void AddUnitInRange(Unit unit)
    {
        if (Target == null) Target = unit;
    }

    private void RemoveUnitInRange(Unit unit)
    {
        if (Target == unit)
        {
            Target = null;
        }            
    }

    private void FindNewUnit()
    {
        var minDistance = float.MaxValue;
        int posMin = 0;
        for(int i = 0; i < unitsInRange.ListUnits.Count; i++)
        {
            var dist = Vector3.Distance(transformUnit.position, unitsInRange.ListUnits[i].transform.position);
            if(dist < minDistance)
            {
                minDistance = dist;
                Target = unitsInRange.ListUnits[i];
            }
        }
    }
}