using UnityEngine;

public class CollitionChangeRoom : MonoBehaviour
{
    [SerializeField] int actualRoom;
    [SerializeField] Transform positionOfCameraInNewRoom;
    [SerializeField] CameraMovement mainCamera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (actualRoom != GameManager.currentRoom && collision.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            GameManager.currentRoom = actualRoom;
            Vector2 newPosition = positionOfCameraInNewRoom.transform.position;
            mainCamera.ChangeRoom(newPosition);
        }
    }

}
