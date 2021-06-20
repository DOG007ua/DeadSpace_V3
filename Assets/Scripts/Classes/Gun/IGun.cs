using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun 
{
    InputPropertyGun Property { get; }
    bool IsCanShoot { get; }
    bool IsReload { get; }
    bool IsReloadAfterShoot { get; }
    void Reload();
    void Shoot(Vector3 positionShoot);
    void Execute();

}
