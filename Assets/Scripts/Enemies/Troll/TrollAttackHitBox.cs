using UnityEngine;

public class TrollAttackHitBox : MonoBehaviour
{
    private float attackdamage;
    [SerializeField] TrollSo data;
    private void Start()
    {
        attackdamage = data.attackDamage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerHealth player = other.GetComponentInChildren<PlayerHealth>();
            player.ReciveDamage(attackdamage);
        }
    }

}
