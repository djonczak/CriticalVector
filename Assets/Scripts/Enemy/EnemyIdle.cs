using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    [Header("Idle Settings")]
    [SerializeField] private float eyesRange = 0.85f;
    [SerializeField] private LayerMask playerLayer = 8;
    public ParticleSystem spottedParticle;
    [SerializeField] private Collider2D[] withinCircle;

    private Transform player;

    private void Update()
    {
        if (GetComponent<EnemyHP>().isDead == false)
        {
            EnemySpotting();
        }
    }

    private void EnemySpotting()
    {
        withinCircle = Physics2D.OverlapCircleAll(transform.position, eyesRange, playerLayer);
        if (withinCircle.Length > 0)
        {
            foreach (Collider2D enemy in withinCircle)
            {
                player = enemy.transform;
                spottedParticle.Play();
                GetComponent<EnemyFollow>().target = player;
                GetComponent<EnemyAttack>().enabled = true;
                GetComponent<EnemyAttack>().player = player.gameObject;
                this.enabled = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, eyesRange);
    }
}
