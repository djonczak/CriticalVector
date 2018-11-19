using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, IDamage
{
    public ParticleSystem damage;
    public float characterHP;
    private Animator anim;
    public bool isDead;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        damage.Play();
        characterHP -= amount;
        if(characterHP <= 0)
        {
            isDead = true;
            StartCoroutine("Death", 0.8f);
        }//"If everyone is complaining, then it's not broken" - Bethesda
    }

    IEnumerator Death(float time)
    {
        anim.SetTrigger("isDeath");
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
