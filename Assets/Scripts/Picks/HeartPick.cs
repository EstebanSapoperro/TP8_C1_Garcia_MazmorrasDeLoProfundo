using UnityEngine;
// Suggestion: using System sin usar.
using System;
public class HeartPick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Warning: String mágico "Player". Usá una const compartida.
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();
            // Suggestion: La cantidad de curación 30 está repetida acá y en PlayerHealth.RegenHealth. Llevala a PlayerSo (consigna D1) y hacé el clamp dentro de PlayerHealth.
            if (PlayerGameManager.playerHealth + 30 > PlayerGameManager.maxPlayerHealth && playerhealth != null)
            {
                // Error: Agarrar el corazón no reproduce ningún sonido ni animación (consigna: toda acción con sonido). El prefab Heart no tiene AudioSource.
                playerhealth.RegenMaxHealth();
                Destroy(gameObject);
            }
            else if (playerhealth != null)
            {
                playerhealth.RegenHealth();
                Destroy(gameObject);
            }
        }
    }
}
