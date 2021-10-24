using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GunFeature
{
    private Unit unit;
    public GunFeature(Unit unit)
    {
        this.unit = unit;
    }

    public int AmmoInShop => unit.weaponController.MainGun.NowAmmoInShop;
    public int MaxInShop => unit.weaponController.MainGun.Property.MaxAmmo;
    public float MaxTimeReload => unit.weaponController.MainGun.Property.TimeReload;
    public float NowTimeReload => unit.weaponController.MainGun.NowTimeAfterStartReload;
    public string Name => unit.weaponController.MainGun.name;

}