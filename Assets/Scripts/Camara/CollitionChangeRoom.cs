using UnityEngine;

// Suggestion: 'Collition' está mal escrito (Collision). Lo mismo la carpeta 'Camara' (Camera).
public class CollitionChangeRoom : MonoBehaviour
{
    [SerializeField] int actualRoom;
    [SerializeField] Transform positionOfCameraInNewRoom;
    [SerializeField] CameraMovement mainCamera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Warning: String mágico "Player" con NameToLayer en cada trigger. Guardalo en una const o usá un LayerMask serializado.
        if (actualRoom != GameManager.currentRoom && collision.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            GameManager.currentRoom = actualRoom;
            Vector2 newPosition = positionOfCameraInNewRoom.transform.position;
            mainCamera.ChangeRoom(newPosition);
        }
    }

}
