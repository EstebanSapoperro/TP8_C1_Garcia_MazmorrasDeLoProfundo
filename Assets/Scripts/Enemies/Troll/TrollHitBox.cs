using UnityEngine;

// Suggestion: Código muerto. Este script no está en ningún prefab ni escena, 'life' no se usa y la variable local de la línea 10 tampoco.
// Borralo.
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
