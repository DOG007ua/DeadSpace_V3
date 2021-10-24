using Assets.Scripts.Classes.Gun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public IUnitController UnitController;
    public TeamUnit Team { get; protected set; }
    
    public GameObject GameObject { get; private set; }
    public bool IsInitialize { get; private set; }

    public string Name = "Unit";

    public float HP 
    {
        get => hp;
        private set
        {
            hp = value;
            if(hp < 0)
            {
                Dead();
            }
        }
    }
    
    public IMove moveUnit { get; protected set; }
    public ISelectUnit selectUnit { get; protected set; }
    public IUnitsInRange unitsInRange { get; protected set; }
    public IControlerTarget controllerTarget { get; protected set; }
    public IWeaponController weaponController { get; protected set; }
    protected List<IComponent> listComponents = new List<IComponent>();
    protected UnitData inputUnitData;
    private float hp;


    protected virtual void Initialize(GameObject thisGameObject)
    {
        if (IsInitialize) return;
        SetInputData();
        HP = inputUnitData.property.HPMax;
        GameObject = this.gameObject;
        CreateSelectUnit(thisGameObject);
        CreateUnitInRange(thisGameObject);
        CreateControllerTarget(thisGameObject);
        CreateWeaponController(thisGameObject);
        IsInitialize = true;
    }

    private void SetInputData()
    {
        var inputScript = GetComponent<UnitInputData>();
        inputUnitData = inputScript.inputUnitData;
        Destroy(inputScript);
    }

    private void CreateWeaponController(GameObject thisGameObject)
    {
        weaponController = GetComponentInChildren<IWeaponController>();
    }

    private void CreateSelectUnit(GameObject thisGameObject)
    {
        var selectPartycle = Instantiate(inputUnitData.prefabSelectCircle);
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

    public void SetHP(float value)
    {
        HP = value;
    }

    public void Damage(float damage)
    {
        UnitController.Damage(damage);
    }

    public virtual void Dead()
    {
        GameObject.Destroy(gameObject);
    }
}
