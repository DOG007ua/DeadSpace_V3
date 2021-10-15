using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class BlueUnitController : IUnitController
{
    public Unit Target => controllerTarget.Target;
    public Unit Unit { get; private set; }

    private IMove moveUnit;
    private ISelectUnit selectUnit;
    private IUnitsInRange unitsInRange;
    private IControlerTarget controllerTarget;
    private IWeaponController weaponController;
   

    public BlueUnitController(Unit unit,  IMove moveUnit, ISelectUnit selectUnit, IUnitsInRange unitsInRange, IControlerTarget controllerTarget, IWeaponController weaponController)
    {
        this.Unit = unit;
        this.moveUnit = moveUnit;
        this.selectUnit = selectUnit;
        this.unitsInRange = unitsInRange;
        this.controllerTarget = controllerTarget;
        this.weaponController = weaponController;
    }

    public void Execute()
    {
        LookAtTarget();
        ShootAtTarget();
    }

    private void LookAtTarget()
    {
        if(!moveUnit.IsMove && controllerTarget.Target != null)
        {
            Unit.transform.LookAt(controllerTarget.Target.transform.position);
        }
    }

    private void ShootAtTarget()
    {
        if (!moveUnit.IsMove && controllerTarget.Target != null)
        {
            var distance = Vector3.Distance(Unit.transform.position, Target.transform.position);
            if(distance < weaponController.MainGun.Property.RangeShoot)
            {
                weaponController.Shoot(Target.transform.position);
            }
            
        }
    }

    public void MoveToPosition(Vector3 position)
    {
        moveUnit.MoveToPosition(position);
    }

    public void SelectUnit(bool value)
    {
        selectUnit.IsSelect = value;
    }

    public void SetTarget(Unit target)
    {
        controllerTarget.SetTarget(target);
    }

    public void Damage(float damage)
    {
        Unit.HP -= damage;
        if (Unit.HP <= 0) GameObject.Destroy(Unit.gameObject);
    }
}