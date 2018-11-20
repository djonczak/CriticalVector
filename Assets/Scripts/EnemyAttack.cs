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
                    Attack(player);
                }
            }
        }
    }

    private void Attack(Collider2D player)
    {
            var distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= attackRadius)
            {
                timer += Time.deltaTime;
                if (timer >= 3f)
                {
                    anim.SetTrigger("isAttack");
                    player.GetComponent<PlayerHP>().TakeDamage(damage);
                    timer = 0f;
                }
            }
        
    }
}
