using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected List<IComponent> listComponents = new List<IComponent>();
    [SerializeField] protected UnitData unitData;
    public IMove moveUnit;
    public ISelectUnit selectUnit;
    public IUnitsInRange unitsInRange;
    public IControlerTarget controllerTarget;
    public TeamUnit Team { get; protected set; }

    void Start()
    {
        
    }

    protected virtual void Initialize(GameObject thisGameObject)
    {
        CreateSelectUnit(thisGameObject);
        CreateUnitInRange(thisGameObject);
        CreateControllerTarget(thisGameObject);
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
}
