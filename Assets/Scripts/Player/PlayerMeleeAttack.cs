using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private float meleeDamage = 1f;

    private PlayerMovement playerMovement;
    private int i = 0;
    private bool canAttack = true;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Attack()
    {
        if (canAttack == true)
        {
            i++;
            GetComponent<IAnimation>().MeleeAnim("Attack" + i);
            playerMovement.isFighting = true;
            canAttack = false;
            Debug.Log(canAttack);
        }
    }

    public void EndAttack()
    {
        canAttack = true;
        playerMovement.isFighting = false;
        Debug.Log(canAttack);
        if (i == 3)
        {
            i = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
           collision.GetComponent<IDamage>().TakeDamage(meleeDamage);
        }
    }
}
