using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float durationTime;

    private void OnEnable()
    {
        StartCoroutine("Cooldown", durationTime);
    }

    private IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Environment")
        {
            StopAllCoroutines();
            this.gameObject.SetActive(false);
        }

        if (collision.tag == "Enemy")
        {
            StopAllCoroutines();
            collision.GetComponent<IDamage>().TakeDamage(1);
            this.gameObject.SetActive(false);
        }
    }

}

