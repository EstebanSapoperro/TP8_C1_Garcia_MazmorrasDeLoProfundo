using UnityEngine;
using System.Collections;
public class CameraMovement : MonoBehaviour
{

    public void ChangeRoom(Vector2 NewPosition)
    {
        StartCoroutine(MoveToPosition(NewPosition));
    }
    IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        Vector3 startPosition = transform.position;

        Debug.Log("Posición inicial: " + startPosition);
        Debug.Log("Posición objetivo: " + targetPosition);

        float duration = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            transform.position = Vector3.Lerp(
                startPosition,
                new Vector3(targetPosition.x, targetPosition.y, startPosition.z),
                t
            );

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Posición final: " + transform.position);
    }

}
