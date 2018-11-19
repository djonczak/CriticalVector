using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, IDamage
{
    public ParticleSystem damage;
    public float characterHP;
    
    public void TakeDamage(float amount)
    {
        damage.Play();
        characterHP -= amount;
        if(characterHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
