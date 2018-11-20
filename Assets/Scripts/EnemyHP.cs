using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, IDamage
{
    public ParticleSystem damage;
    public float characterHP;
    private Animator anim;
    public bool isDead;
    bool isDamaged;

    private SpriteRenderer enemyColor;
    public Color enemyNormalState;
    private Color enemyDamage = Color.red;

    public void Start()
    {
        anim = GetComponent<Animator>();
        enemyColor = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isDamaged)
        {
            enemyColor.color = Color.Lerp(enemyDamage, enemyNormalState, Time.deltaTime);
        }
        else
        {
            enemyColor.color = Color.Lerp(enemyNormalState, enemyDamage, Time.deltaTime);
        }
    }

    public void TakeDamage(float amount)
    {
        damage.Play();
        characterHP -= amount;
        StartCoroutine("DamageEffect", 0.5f);
        if(characterHP <= 0)
        {
            isDead = true;
            GameManager.instance.virusKill++;
            StartCoroutine("Death", 0.8f);
        }//"If everyone is complaining, then it's not broken" - Bethesda
    }

    IEnumerator Death(float time)
    {
        anim.SetTrigger("isDeath");
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    IEnumerator DamageEffect(float time)
    {
        isDamaged = true;
        yield return new WaitForSeconds(time);
        isDamaged = false;
    }
}
