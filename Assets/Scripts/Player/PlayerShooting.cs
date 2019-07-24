using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public float bulletSpeed;
    public float maxAmount;
    private float currentAmount;
    public Image ammoBar;
    private Animator anim;
    private PlayerMovement playerMovement;
    public Transform point;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        currentAmount = maxAmount;
    }

    public void Shoot()
    {
        if (currentAmount > 0)
        {
            currentAmount--;
            ammoBar.fillAmount = currentAmount / maxAmount;
            anim.SetTrigger("IsShooting");
            playerMovement.isFighting = true;
            Debug.Log("Strzelił");
        }
    }

    public void ProjectileStart()
    {
        GameObject bullet = ObjectPooler.instance.GetPooledObject("Bullet");
        bullet.transform.position = point.transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
    }

    public void StopShooting()
    {
        playerMovement.isFighting = false;
        Debug.Log("Powinien się wyłączyć");
    }
}
