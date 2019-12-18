using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    [Header("Range Attack Settings")]
    [SerializeField] private float bulletMaxAmount = 5f;
    [SerializeField] private float bulletCurrentAmount = 0f;
    [SerializeField] private bool canShoot = true;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
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
