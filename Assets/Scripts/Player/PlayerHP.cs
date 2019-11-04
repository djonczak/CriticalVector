using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamage
{
    public float maxPlayerHP;
    public float currentPlayerHP;

    void Start()
    {
        currentPlayerHP = maxPlayerHP;
    }

    public void TakeDamage(float amount)
    {
        currentPlayerHP -= amount;
        Debug.Log(amount);
        PlayerUI.instance.Damaged();
        GetComponent<IEffect>().ShowEffect();
        if (currentPlayerHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
