using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Melee Attack Settings")]
    [SerializeField] private float attackDamage = 1f;
    [SerializeField] private float attackSpeed = 0.5f;
    [SerializeField] private float attackRadius = 0.59f;
    public GameObject player;

    private Animator anim;
    private float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
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
                    player.GetComponent<IDamage>().TakeDamage(attackDamage);
                    timer = 0f;
                }
            }
        }      
    }
}
