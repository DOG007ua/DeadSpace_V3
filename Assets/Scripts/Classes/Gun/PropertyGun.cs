using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Input property gun", menuName = "Data/Input property gun", order = 52)]
public class InputPropertyGun : ScriptableObject
{
    public TypeAmmo TypeAmmo;
    public int MaxAmmo;
    public float TimeReload;
    public float TimeBetweenShoot;
    public float RangeShoot;
    public float Dispersion;
    public float Damage;
    public GameObject bullet;
}
