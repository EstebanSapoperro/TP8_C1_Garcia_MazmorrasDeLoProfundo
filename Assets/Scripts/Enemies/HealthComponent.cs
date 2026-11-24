using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    private float maxHealth = 100;
    // Suggestion: Código comentado. Si no se usa, borralo; el historial queda en git.
    //[SerializeField] private AudioSource hitEffect;
    //[SerializeField] private AudioClip hitClipEffect;
    [SerializeField] private SpriteRenderer originalSprite;
    [SerializeField] private AudioSource diyingSFX;
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
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        StartCoroutine(FlashEffect(originalColor, flashColor,originalSprite,flashTime));

        // Bug: No hay un flag de muerte. Si el troll recibe otro golpe durante los 0.6 s de Die(), se vuelve a iniciar Die(),
        // se reinicia diyingSFX y la barra queda con fillAmount negativo. Agregá un bool isDead y retorná al principio de DoDamage.
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
        // Suggestion: else vacío, código muerto.
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

    // Error: La consigna pide feedback visual al morir con partículas + animación. Solo hay animación "Dead",
    // no hay ningún ParticleSystem en el prefab EnemyTroll ni en las escenas.
    IEnumerator Die() 
    {
        diyingSFX.Play();
        bodyMovement.Stop();
        // Suggestion: Nombre de estado "Dead" y espera 0.6f mágicos. Usá const o un hash (Animator.StringToHash) y llevá la duración al SO.
        animatio.Play("Dead");
        yield return new WaitForSeconds(0.6f);
        Destroy(fatherObject);
    }
}
