using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Melee Attack Settings")]
    public float attackDamage;
    public float attackSpeed;
    public float attackRadius;
    public GameObject player;

    private Animator anim;
    float timer;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (GetComponent<EnemyHP>().isDead == false)
        {
            var distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= attackRadius)
            {
                timer += Time.deltaTime;
                if (timer >= attackSpeed)
                {
                    anim.SetTrigger("isAttack");
                    player.GetComponent<PlayerHP>().TakeDamage(attackDamage);
                    timer = 0f;
                }
            }
        }      
    }
}
