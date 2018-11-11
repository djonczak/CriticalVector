using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    public float attackRadius;
    public LayerMask enemyLayer;

    private PlayerMovement player;
    private Collider2D[] withinCircle;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        DashAttack();
    }

    private void DashAttack()
    {
        if (player.isDashing)
        {
            withinCircle = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);
            if (withinCircle.Length > 0)
            {
                foreach (Collider2D enemy in withinCircle)
                {
                    Debug.Log("Dostał");
                    enemy.GetComponent<EnemyHP>().TakeDamage(damage);
                }
            }
        }
    }
}
