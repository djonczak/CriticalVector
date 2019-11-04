using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour, IDamage
{
    public float maxHP;
    [SerializeField]
    private float currentHP;
    public Image hpBar;
    private Animator anim;
    public bool isDead;

    bool isDamaged;

    public void Start()
    {
        anim = GetComponent<Animator>();
        currentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        if (isDamaged == false)
        {
            currentHP -= amount;
            hpBar.fillAmount = currentHP / maxHP;
            StartCoroutine("DamageCooldown", 0.5f);
            GetComponent<IEffect>().ShowEffect();
            if (currentHP <= 0)
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
                isDead = true;
                anim.SetTrigger("isDeath");
            }
        }
    }

    public void Death()
    {
        GameManager.instance.virusKill++;
        gameObject.SetActive(false);
    }

    IEnumerator DamageCooldown(float time)
    {
        isDamaged = true;
        yield return new WaitForSeconds(time);
        isDamaged = false;
    }
}
