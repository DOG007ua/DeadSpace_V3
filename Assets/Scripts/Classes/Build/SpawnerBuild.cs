using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerBuild : MonoBehaviour, IBuild, ICreateUnit
{
    public Transform positionSpawn;
    protected bool IsNeedSpawn = true;
    protected bool readySpawn = true;


    public void Initialize()
    {

    }

    public void SpawnUnit(GameObject prefab, float seconds)
    {
        StartCoroutine(StartSpawnUnit(prefab, seconds));
    }

    private void CreateUnit(GameObject prefab)
    {
        var unitGameObject = Instantiate(prefab);
        var unit = unitGameObject.GetComponent<Unit>();
        unitGameObject.transform.position = positionSpawn.position;
        StartCoroutine(SettingsAfterSpawn(unit));
    }

    protected IEnumerator StartSpawnUnit(GameObject prefab, float seconds)
    {
        readySpawn = false;
        yield return new WaitForSeconds(seconds);
        CreateUnit(prefab);
        readySpawn = true;
    }

    protected virtual void SettingsUnit(Unit unit)
    {
    }

    //Инициализация юнита происходит позже, поэтому задаю настройки в след кадре
    private IEnumerator SettingsAfterSpawn(Unit unit)
    {
        yield return null;
        SettingsUnit(unit);
    }
}
