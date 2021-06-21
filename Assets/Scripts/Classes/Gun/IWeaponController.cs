using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes.Gun
{
    interface IWeaponController
    {
        public void Reload();
        public Gun MainGun { get; set; }
        public Gun SecondGun { get; set; }
        public void Shoot(Vector3 position);
        public bool IsCanShoot { get; }
    }
}
