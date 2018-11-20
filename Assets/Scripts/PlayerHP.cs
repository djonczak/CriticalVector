using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamage
{
    public float playerHP;
    private SpriteRenderer playerColor;
    public Color playerNormalState;
    private Color playerDamage = Color.red;
    bool isDamaged;

    void Start()
    {
        playerColor = GetComponent<SpriteRenderer>();
        playerNormalState = playerColor.color;
    }

    public void Update()
    {
        if (isDamaged)
        {
            playerColor.color = Color.Lerp(playerDamage, playerNormalState, Time.deltaTime);
        }
        else
        {
            playerColor.color = Color.Lerp(playerNormalState, playerDamage, Time.deltaTime);
        }
    }

    public void TakeDamage(float amount)
    {
        playerHP -= amount;
        StartCoroutine("DamageEffect", 1f);
        if (playerHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator DamageEffect(float time)
    {
        isDamaged = true;
        yield return new WaitForSeconds(time);
        isDamaged = false;
    }
}
