using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    [Header("Range Attack Settings")]
    public float bulletMaxAmount;
    public float bulletCurrentAmount;
    private PlayerMovement playerMovement;
    [SerializeField]
    private bool canShoot = true;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        bulletCurrentAmount = bulletMaxAmount;
    }

    public void Shoot()
    {
        if (bulletCurrentAmount > 0 && canShoot == true)
        {
            bulletCurrentAmount--;
            PlayerUI.instance.AmmunitionUpdate(bulletCurrentAmount, bulletMaxAmount);
            GetComponent<IAnimation>().RangeAnim();
            playerMovement.isFighting = true;
            canShoot = false;
        }
    }

    public void Launch()
    {
        GetComponent<ILaunch>().LaunchProjectile();
    }

    public void StopShooting()
    {
        playerMovement.isFighting = false;
        canShoot = true;
    }
}
