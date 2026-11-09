using UnityEngine;
using System;
public class DoorBehabour : MonoBehaviour
{
    public static event Action OnWining;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (GameManager.currentKeys > 0) 
            {
                GameManager.currentKeys--;
                OnWining?.Invoke();
            }
        }
    }

}
