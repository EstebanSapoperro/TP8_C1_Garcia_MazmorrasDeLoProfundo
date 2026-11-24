using UnityEngine;
using System;
// Suggestion: Nombre con error de tipeo ('Behabour' por Behaviour, 'OnWining' por OnWinning).
// Además el script está suelto en Assets/Scripts/, movelo a una subcarpeta (Game/).
public class DoorBehabour : MonoBehaviour
{
    public static event Action OnWining;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Warning: String mágico "Player". Centralizá los nombres de capa en una clase de constantes.
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
