using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    private Animator anim;
    private PlayerMovement playerMovement;
    int i=0;
    bool canAttack = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Attack()
    {
        Debug.Log(canAttack);
        if (canAttack == true)
        {
            Debug.Log("Atak");
            i++;
            anim.SetTrigger("Attack" + i);
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
                Debug.Log("ciach");
                collision.GetComponent<IDamage>().TakeDamage(damage);
            }
    }
}
