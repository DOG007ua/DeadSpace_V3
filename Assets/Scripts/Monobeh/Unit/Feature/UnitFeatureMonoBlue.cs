using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class UnitFeatureMonoBlue : MonoBehaviour
{
    private UnitFeature feature;
    public float HP;
    public int MaxAmmo;
    public int NowAmmo;

    public void Initialize(Unit unit)
    {
        feature = new UnitFeature(unit);
    }

    private void Update()
    {
        HP = feature.Main.HP;
        MaxAmmo = feature.Gun.MaxInShop;
        NowAmmo = feature.Gun.AmmoInShop;
    }
}