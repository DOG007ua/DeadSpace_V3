using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Input property gun", menuName = "Input property gun", order = 52)]
public class InputPropertyGun : ScriptableObject
{
    TypeAmmo TypeAmmo;
    int MaxAmmo;
    float TimeReload;
    float TimeBetweenShoot;
    float RangeShoot;
}