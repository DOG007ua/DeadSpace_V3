using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun 
{
    InputPropertyGun Property { get; }
    bool IsCanShoot { get; }
    void Reload();
    void Shoot();

}
