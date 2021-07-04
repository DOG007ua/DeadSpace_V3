using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Gun : MonoBehaviour, IGun
{
    public InputPropertyGun Property { get; private set; }
    public virtual bool IsCanShoot =>
        !IsReload &&
        !IsReloadAfterShoot &&
        nowAmmoInShop > 0;

    public bool IsReload { get; private set; }

    public bool IsReloadAfterShoot { get; private set; }

    protected float nowTimeAfterShoot;
    protected float nowTimeAfterStartReload;
    protected int nowAmmoInShop;
    private Transform pointSpawnBullet;

    public void Initialize(Transform gun, InputPropertyGun property)
    {
        Property = property;
        FindSpawnPoint(gun);
    }

    private void FindSpawnPoint(Transform gun)
    {
        for (int i = 0; i < gun.childCount; i++)
        {
            var child = gun.GetChild(i);
            if (child.name == "Spawn")
            {
                pointSpawnBullet = child;
                break;
            }
        }
    }

    public void Execute()
    {
        ReloadAction();
        ReloadAfterShootAction();
    }

    public void Reload()
    {
        IsReload = true;
    }

    private void ReloadAction()
    {
        if (IsReload)
        {
            nowTimeAfterStartReload += Time.deltaTime;
            if (nowTimeAfterStartReload >= Property.TimeReload)
            {
                nowTimeAfterStartReload = 0;
                IsReload = false;
            }
        }
    }

    private void ReloadAfterShootAction()
    {
        if (IsReloadAfterShoot)
        {
            nowTimeAfterShoot += Time.deltaTime;
            if (nowTimeAfterShoot >= Property.TimeBetweenShoot)
            {
                nowTimeAfterShoot = 0;
                IsReloadAfterShoot = false;
            }
        }
    }

    public virtual void Shoot(Vector3 positionShoot)
    {
        if (IsCanShoot) return;
        if (nowAmmoInShop <= 0) return;

        nowAmmoInShop -= 1;
        SpawnBullet(positionShoot);
        IsReloadAfterShoot = true;

        if (nowAmmoInShop <= 0) Reload();
    }

    public void SpawnBullet(Vector3 positionShoot)
    {
        var bullet = GameObject.Instantiate(Property.bullet);
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Initialize(Property.Damage);

        bullet.transform.position = pointSpawnBullet.position;
        var direction = -(pointSpawnBullet.position - positionShoot).normalized;
        bullet.transform.rotation = Quaternion.LookRotation(direction);
        CalculationDispersion(bullet);
    }

    private void CalculationDispersion(GameObject bullet)
    {
        var dispersionX = UnityEngine.Random.Range(0, Property.Dispersion);
        var dispersionY = UnityEngine.Random.Range(0, Property.Dispersion);
        bullet.transform.Rotate(dispersionX, dispersionY, 0);
    }
}