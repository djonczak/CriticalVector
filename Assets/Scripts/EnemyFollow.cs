using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float spotRange;
    public float moveSpeed;
    public LayerMask playerLayer;
    public ParticleSystem spoted;
    private Animator anim;
    private SpriteRenderer character;
    private Collider2D[] withinCircle;

    private Transform player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (GetComponent<EnemyHP>().isDead == false)
        {
            EnemySpotting();
            EnemyMove();
            if (player != null)
            {
                StartCoroutine("Spotted", 0.8f);
            }
        }
    }

    void EnemySpotting()
    {
        withinCircle = Physics2D.OverlapCircleAll(transform.position, spotRange, playerLayer);
        if (withinCircle.Length > 0)
        {
            foreach (Collider2D enemy in withinCircle)
            {
                player = enemy.transform;          
            }
        }
    }

    private void EnemyMove()
    {
        if (player != null)
        {
            var target = new Vector2(player.position.x, player.position.y);
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            if (target.x > transform.position.x)
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spotRange);
    }

    IEnumerator Spotted(float time)
    {
        spoted.Play();
        yield return new WaitForSeconds(time);
        spoted.gameObject.SetActive(false);
    }
}
