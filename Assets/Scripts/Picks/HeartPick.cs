using UnityEngine;
using System;
public class HeartPick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();
            if (PlayerGameManager.playerHealth + 30 > PlayerGameManager.maxPlayerHealth && playerhealth != null)
            {
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
