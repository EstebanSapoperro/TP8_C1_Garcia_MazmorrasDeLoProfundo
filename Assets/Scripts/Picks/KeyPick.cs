using UnityEngine;

public class KeyPick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.currentKeys++;
            GameObject.Destroy(gameObject);
        }
    }

}
