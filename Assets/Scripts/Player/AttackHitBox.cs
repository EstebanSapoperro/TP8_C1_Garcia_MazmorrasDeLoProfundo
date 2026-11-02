using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    [SerializeField] private PlayerSo data;
    //[SerializeField] private AudioSource slashEffect;
    //[SerializeField] private AudioClip slashClipEffect;
    private float slashDamage;
    private void Start()
    {
        slashDamage = data.slashDamage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            HealthComponent enemyLife = other.GetComponentInChildren<HealthComponent>();
            enemyLife.DoDamage(slashDamage);
        }
    }
}
