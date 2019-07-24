using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour, IDamage
{
    public ParticleSystem damage;
    public float maxHP;
    private float currentHP;
    public Image hpBar;
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
        currentHP = maxHP;
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
        if (isDamaged == false)
        {
            damage.Play();
            currentHP -= amount;
            hpBar.fillAmount = currentHP / maxHP;
            StartCoroutine("DamageEffect", 0.5f);
            if (currentHP <= 0)
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
                isDead = true;
                StartCoroutine("Death", 0.8f);
            }
        }
    }

    IEnumerator Death(float time)
    {
        anim.SetTrigger("isDeath");
        yield return new WaitForSeconds(time);
        GameManager.instance.virusKill++;
        gameObject.SetActive(false);
    }

    IEnumerator DamageEffect(float time)
    {
        isDamaged = true;
        yield return new WaitForSeconds(time);
        isDamaged = false;
    }


}
