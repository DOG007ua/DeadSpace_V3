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