using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILaunch
{
    [Header("Launcher Setting")]
    public string bulletName;
    public Transform barrel;
    public float bulletSpeed;

    public void LaunchProjectile()
    {
        GameObject bullet = ObjectPooler.instance.GetPooledObject(bulletName);
        bullet.transform.position = barrel.transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }

}
