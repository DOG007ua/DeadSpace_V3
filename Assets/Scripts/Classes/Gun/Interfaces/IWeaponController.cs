using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IWeaponController
{
    void Reload();
    Gun MainGun { get; set; }
    Gun SecondGun { get; set; }
    void Shoot(Vector3 position);
    bool IsCanShoot { get; }
}