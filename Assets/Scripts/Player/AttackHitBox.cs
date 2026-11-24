using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    [SerializeField] private PlayerSo data;
    // Suggestion: Código comentado, borralo.
    //[SerializeField] private AudioSource slashEffect;
    //[SerializeField] private AudioClip slashClipEffect;
    private float slashDamage;
    private void Start()
    {
        slashDamage = data.slashDamage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Warning: String mágico "Enemies". Usá una const o un LayerMask serializado.
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            // Warning: Sin null check sobre enemyLife. Si otro objeto de la capa Enemies no tiene HealthComponent, NullReferenceException.
            HealthComponent enemyLife = other.GetComponentInChildren<HealthComponent>();
            enemyLife.DoDamage(slashDamage);
        }
    }
}
