using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    private float maxHealth = 100;
    //[SerializeField] private AudioSource hitEffect;
    //[SerializeField] private AudioClip hitClipEffect;
    [SerializeField] private SpriteRenderer originalSprite;
    private Color originalColor;
    private Color flashColor = Color.red;
    private float flashTime = 0.3f;
    [SerializeField] private TrollSo data;
    [SerializeField] private GameObject fatherObject;
    [SerializeField] private Animator animatio;
    [SerializeField] private TrollMovement bodyMovement;
    [SerializeField] private Image healthBar;
    private float health;
    private void Start()
    {
        flashTime = data.flashTime;
        originalColor = originalSprite.color;
        maxHealth = data.enemyHealth;
        health = maxHealth;
    }
    public void DoDamage(float damage) 
    {
        //hitEffect.pitch = Random.Range(0.9f, 1.1f);
        //hitEffect.PlayOneShot(hitClipEffect);
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        Debug.Log("recibio daño");
        StartCoroutine(FlashEffect(originalColor, flashColor,originalSprite,flashTime));

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
        else 
        {
        
        }
    }
    IEnumerator FlashEffect(Color originalColor, Color flashColor, SpriteRenderer originalSprite, float flashTime) 
    {
        originalSprite.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        originalSprite.color = originalColor;
    }

    IEnumerator Die() 
    {
        Debug.Log("Se murio el enemigo");
        bodyMovement.Stop();
        animatio.Play("Dead");
        yield return new WaitForSeconds(0.6f);
        Destroy(fatherObject);
    }
}
