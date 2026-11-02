using UnityEngine;

public class TrollHitBox : MonoBehaviour
{
    [SerializeField] HealthComponent life;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack"))
        {
            HealthComponent enemyLife = other.GetComponentInChildren<HealthComponent>();
        }
    }
}
