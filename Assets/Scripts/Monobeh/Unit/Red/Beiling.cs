using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Beiling : RedTeam
{
    private float distanceDamage = 3;
    private float distanceBooom = 2;
    private float damage = 20;

    private void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        Initialize(this.gameObject);        
        
    }

    private void Update()
    {
        Execute();
        MoveToTarget();
        if (MinDistanceTarget())
        {
            Dead();
        }
    }

    private void MoveToTarget()
    {
        if(controllerTarget.HasTarget)
        {
            moveUnit.MoveToPosition(controllerTarget.Target.transform.position);
        }
    }

    private bool MinDistanceTarget()
    {
        if (!controllerTarget.HasTarget) return false;

        var distance = Vector3.Distance(transform.position, controllerTarget.Target.transform.position);
        if (distance < distanceBooom) return true;
        else return false;
    }

    public override void Dead()
    {
        foreach(var unit  in unitsInRange.ListUnits)
        {
            var distance = Vector3.Distance(transform.position, unit.transform.position);
            if (distance < distanceDamage)
            {
                unit.Damage(damage);
            }
        }
        base.Dead();
    }
}