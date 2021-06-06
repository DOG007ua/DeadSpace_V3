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

    void Start()
    {
        
    }

    protected virtual void Initialize(GameObject thisGameObject)
    {
        CreateSelectUnit(thisGameObject);
        CreateUnitInRange(thisGameObject);
    }

    private void CreateSelectUnit(GameObject thisGameObject)
    {
        var selectPartycle = Instantiate(unitData.prefabSelectCircle);
        selectPartycle.transform.parent = thisGameObject.transform;
        selectPartycle.transform.position = new Vector3(0, 0.5f, 0);

        selectUnit = selectPartycle.GetComponent<ISelectUnit>();
    }

    private void CreateUnitInRange(GameObject thisGameObject)
    {
        var go = new GameObject("UnitInRange");
        go.transform.parent = thisGameObject.transform;
        unitsInRange = go.AddComponent<UnitsInRange>();
        unitsInRange.Initialize(5);
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
