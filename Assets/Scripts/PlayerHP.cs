using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamage
{
    public float playerHP;
    private SpriteRenderer playerColor;
    public Color playerNormalState;
    private Color playerDamage = Color.red;

    void Start()
    {
        playerColor = GetComponent<SpriteRenderer>();
        playerNormalState = playerColor.color;
    }

    public void TakeDamage(float amount)
    {
        playerHP -= amount;
        StartCoroutine("DamageEffect", 2f);
        if (playerHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator DamageEffect(float time)
    {
        playerColor.color = Color.Lerp(playerDamage, playerNormalState, Time.deltaTime);
        yield return new WaitForSeconds(time);
        playerColor.color = Color.Lerp(playerNormalState, playerDamage, Time.deltaTime);
    }
}
