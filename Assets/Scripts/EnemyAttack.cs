using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage;
    public float attackRadius;
    public LayerMask playerLayer;

    private Collider2D[] withinCircle;
    private Animator anim;
    private bool canAttack;
    float timer;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        CheckingPlayer();
    }

    private void CheckingPlayer()
    {
        if (GetComponent<EnemyHP>().isDead == false)
        {
            withinCircle = Physics2D.OverlapCircleAll(transform.position, attackRadius, playerLayer);
            if (withinCircle.Length > 0)
            {
                foreach (Collider2D player in withinCircle)
                {
                    canAttack = true;
                    Attack(player);
                }
            }
        }
    }

    private void Attack(Collider2D player)
    {
        if (canAttack)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                anim.SetTrigger("isAttack");
                player.GetComponent<PlayerHP>().TakeDamage(damage);
                canAttack = false;
                timer = 0f;
            }
        }
    }
}
