using Assets.Scripts.Classes.Gun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class WeaponController : IWeaponController
{
    public Gun MainGun { get; set; }
    public Gun SecondGun { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool IsCanShoot => MainGun.IsCanShoot;

    public void Initialize(Gun mainGun)
    {
        MainGun = mainGun;
    }

    public void Reload()
    {
        MainGun.Reload();
    }

    public void Shoot(Vector3 position)
    {
        MainGun.Shoot(position);
    }
}