using Assets.Scripts.Classes.Gun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class WeaponController : MonoBehaviour, IWeaponController
{
    public Gun MainGun { get; set; }
    public Gun SecondGun { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool IsCanShoot => MainGun.IsCanShoot;

    public void Start()
    {
        MainGun = GetComponentInChildren<Gun>();
    }

    public void RefreshGun(GameObject newGun)
    {
        MainGun = newGun.GetComponentInChildren<Gun>();
        newGun.transform.parent = transform;
        newGun.transform.localPosition = new Vector3(0,0,0.4f);

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