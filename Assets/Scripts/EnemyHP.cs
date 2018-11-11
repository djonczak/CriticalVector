using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, IDamage
{
    public float characterHP;
    
    public void TakeDamage(float amount)
    {
        characterHP -= amount;
        if(characterHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
