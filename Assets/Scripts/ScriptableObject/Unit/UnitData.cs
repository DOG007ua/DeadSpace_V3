using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data unit", menuName = "DataUnit", order = 51)]
public class UnitData : ScriptableObject
{
    public GameObject prefabSelectCircle;
    public GameObject prefabBullet;
    [SerializeField]public UnitProperty property;
}
