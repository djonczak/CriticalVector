using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    private SpriteRenderer character;

    public Transform target;

    private void Start()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (GetComponent<EnemyHP>().isDead == false)
        {
            EnemyMove();
        }
    }

    private void EnemyMove()
    {
        if (target != null)
        { 
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            if (target.transform.position.x > transform.position.x)
            {
                character.flipX = false;
            }
            else
            {
                character.flipX = true;
            }
            anim.SetTrigger("isFollow");
        }
    }
}
