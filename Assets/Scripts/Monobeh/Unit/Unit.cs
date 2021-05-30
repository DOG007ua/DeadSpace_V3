using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected List<IComponent> listComponents;
    [SerializeField] protected UnitData unitData;
    public IMove moveUnit;
    public ISelectUnit selectUnit;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    protected void Execute()
    {
        if (listComponents == null) return;

        foreach(var component in listComponents)
        {
            component.Execute();
        }
    }
}
