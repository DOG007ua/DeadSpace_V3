using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class UnitsInRange : MonoBehaviour, IUnitsInRange
{
    private SphereCollider colliderSphere;
    private float range;
    public event Action<Unit> AddUnit;
    public event Action<Unit> RemoveUnit;
    private TeamUnit filterNeedTeamUnit;
    public List<Unit> ListUnits { get; private set; } = new List<Unit>();

    public float Range 
    { 
        get => range; 
        private set
        {
            range = value;
            colliderSphere.radius = value;
        }
    }
    

    public void AddObject(Unit unit)
    {
        ListUnits.Add(unit);
        AddUnit?.Invoke(unit);
    }

    public void RemoveObject(Unit unit)
    {
        ListUnits.Remove(unit);
        RemoveUnit?.Invoke(unit);
    }

    public void Initialize(float range, TeamUnit filterNeedTeamUnit)
    {
        this.filterNeedTeamUnit = filterNeedTeamUnit;
        ListUnits = new List<Unit>();
        colliderSphere = gameObject.AddComponent<SphereCollider>();
        colliderSphere.isTrigger = true;
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
        var unit = other.gameObject.GetComponent<Unit>();
        
        if(unit != null && unit.Team == filterNeedTeamUnit)
        {
            AddObject(unit);
            Debug.Log("Add" + other.name);
        }        
    }   

    private void OnTriggerExit(Collider other)
    {
        var obj = other.gameObject.GetComponent<Unit>();

        if (obj != null && ListUnits.Contains(obj))
        {
            RemoveObject(obj);
            Debug.Log("Remove" + other.name);
        }
    }
} 