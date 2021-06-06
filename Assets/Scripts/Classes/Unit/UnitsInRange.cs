using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class UnitsInRange : MonoBehaviour, IUnitsInRange
{
    private SphereCollider collider;
    private float range;
    public float Range 
    { 
        get => range; 
        private set
        {
            range = value;
            collider.radius = value;
        }
    }

    public List<Unit> ListUnits { get; private set; }

    public void AddObject(Unit unit)
    {
        ListUnits.Add(unit);
    }

    public void RemoveObject(Unit unit)
    {
        ListUnits.Remove(unit);
    }

    public void Initialize(float range)
    {        
        ListUnits = new List<Unit>();
        collider = gameObject.AddComponent<SphereCollider>();
        collider.isTrigger = true;
        Range = range;
        this.gameObject.layer = 8;
    }    

    public void SetRange(float value)
    {
        Range = value;
        ListUnits = new List<Unit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject.GetComponent<Unit>();
        
        if(obj != null)
        {
            AddObject(obj);
            Debug.LogWarning("Add" + other.name);
        }        
    }   

    private void OnTriggerExit(Collider other)
    {
        var obj = other.gameObject.GetComponent<Unit>();

        if (obj != null)
        {
            RemoveObject(obj);
            Debug.LogWarning("Remove" + other.name);
        }
    }
} 