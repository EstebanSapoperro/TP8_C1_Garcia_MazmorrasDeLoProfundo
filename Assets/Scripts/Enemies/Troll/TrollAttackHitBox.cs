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
        // Warning: String mágico "Player". Usá una const compartida.
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Warning: Sin null check. Si un collider de la capa Player no tiene PlayerHealth en sus hijos, ReciveDamage tira NullReferenceException.
            // Usá TryGetComponent o verificá null antes de llamar.
            PlayerHealth player = other.GetComponentInChildren<PlayerHealth>();
            player.ReciveDamage(attackdamage);
        }
    }

}
