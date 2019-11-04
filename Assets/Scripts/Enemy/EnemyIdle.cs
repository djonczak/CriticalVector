using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    [Header("Idle Settings")]
    public float eyesRange;
    public LayerMask playerLayer;
    public ParticleSystem spottedParticle;
    [SerializeField]
    private Collider2D[] withinCircle;

    private Transform player;

    public void Update()
    {
        if (GetComponent<EnemyHP>().isDead == false)
        {
            EnemySpotting();
        }
    }

    void EnemySpotting()
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
