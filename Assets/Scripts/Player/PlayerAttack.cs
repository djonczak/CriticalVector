using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    public float attackRadius;
    public LayerMask enemyLayer;
    private Animator anim;
    private PlayerMovement playerMovement;
    private Collider2D[] withinCircle;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Attack()
    {
        Debug.Log("Atak");
        anim.SetTrigger("Attack1");
        playerMovement.isFighting = true;
    }

    public void EndAttack()
    {
        playerMovement.isFighting = false;
    }
}
