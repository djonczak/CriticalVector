using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour, IEffect
{
    [Header("Damage effect options")]
    [SerializeField] private float effectDuration = 1f;
    public ParticleSystem damageParticle;
    [SerializeField] private Color normalColor;

    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private bool isDamaged, canSwitchColor;

    private SpriteRenderer sprite;
    private float t = 0f;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        normalColor = sprite.color;
    }

    private void Update()
    {
        if (canSwitchColor)
        {
            t += Time.deltaTime / 1f;
            if (isDamaged)
            {
                sprite.color = Color.Lerp(damageColor, normalColor, t);
            }
        }
    }

    public void ShowEffect()
    {
        StartCoroutine("EffectCooldown", effectDuration);
    }

    private IEnumerator EffectCooldown(float time)
    {
        if (damageParticle != null)
        {
            damageParticle.Play();
        }
        isDamaged = true;
        canSwitchColor = true;
        yield return new WaitForSeconds(time);
        isDamaged = false;
        canSwitchColor = false;
        t = 0f;
    }


}
