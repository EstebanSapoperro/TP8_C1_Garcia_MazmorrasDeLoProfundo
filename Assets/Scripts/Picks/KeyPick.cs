using UnityEngine;

public class KeyPick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Warning: String mágico "Player". Usá una const compartida.
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.currentKeys++;
            GameObject.Destroy(gameObject);
        }
    }

}
