using Assets.Scripts.Classes.Gun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected List<IComponent> listComponents = new List<IComponent>();
    [SerializeField] protected UnitData unitData;
    protected IMove moveUnit;
    protected ISelectUnit selectUnit;
    protected IUnitsInRange unitsInRange;
    protected IControlerTarget controllerTarget;
    protected IWeaponController weaponController;
    public IUnitController UnitController;
    public TeamUnit Team { get; protected set; }
    public GameObject GameObject { get; private set; }

    protected virtual void Initialize(GameObject thisGameObject)
    {
        unitData.property.HP = unitData.property.HPMax;
        GameObject = this.gameObject;
        CreateSelectUnit(thisGameObject);
        CreateUnitInRange(thisGameObject);
        CreateControllerTarget(thisGameObject);
        CreateWeaponController(thisGameObject);
    }

    private void CreateWeaponController(GameObject thisGameObject)
    {
        weaponController = GetComponentInChildren<IWeaponController>();
    }

    private void CreateSelectUnit(GameObject thisGameObject)
    {
        var selectPartycle = Instantiate(unitData.prefabSelectCircle);
        selectPartycle.transform.parent = thisGameObject.transform;
        selectPartycle.transform.localPosition = new Vector3(0, 0.3f, 0);

        selectUnit = selectPartycle.GetComponent<ISelectUnit>();
    }

    private void CreateUnitInRange(GameObject thisGameObject)
    {
        var go = new GameObject("UnitInRange");
        go.transform.parent = thisGameObject.transform;
        go.transform.localPosition = Vector3.zero;
        unitsInRange = go.AddComponent<UnitsInRange>();        
    }

    private void CreateControllerTarget(GameObject thisGameObject)
    {
        controllerTarget = new SelectTargetInRange(unitsInRange, thisGameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    protected void Execute()
    {
        foreach(var component in listComponents)
        {
            component.Execute();
        }
    }

    public void Damage(float damage)
    {
        unitData.property.HP -= damage;
        if (unitData.property.HP <= 0) Destroy(this.gameObject);
    }
}
