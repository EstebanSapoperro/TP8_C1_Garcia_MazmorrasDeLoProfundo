using UnityEngine;
using System.Collections;
public class CameraMovement : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    public void ChangeRoom(Vector2 NewPosition)
    {
        // Warning: Si el jugador cruza dos triggers de cuarto seguidos, arrancan dos corrutinas que mueven la cámara a la vez.
        // Guardá el Coroutine devuelto y hacé StopCoroutine antes de iniciar uno nuevo.
        StartCoroutine(MoveToPosition(NewPosition));
    }
    IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        Vector3 startPosition = transform.position;

        // Suggestion: Duración mágica 0.7f. Pasala a un [SerializeField] o al ScriptableObject de configuración.
        // Además, al salir del while no se asigna la posición final exacta (t nunca llega a 1).
        float duration = 0.7f;
        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;

            transform.position = Vector3.Lerp( startPosition, new Vector3(targetPosition.x, targetPosition.y, startPosition.z),curve.Evaluate(t));
            time += Time.deltaTime;
            yield return null;
        }
    }

}
