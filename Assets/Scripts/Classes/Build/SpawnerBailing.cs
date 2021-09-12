using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBailing : SpawnerBuild
{
    public GameObject unit;
    public float timeSpawn;
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        if(readySpawn && IsNeedSpawn)
        {
            SpawnUnit(unit, timeSpawn);
        }
    }

    protected override void SettingsUnit(Unit unit)
    {
        if(target != null)
        {
            unit.UnitController.SetTarget(target.GetComponent<Unit>());
        }  
    }
}

