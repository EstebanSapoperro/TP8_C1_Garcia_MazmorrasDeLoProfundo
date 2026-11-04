using UnityEngine;
using System.Collections;
public class CameraMovement : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    public void ChangeRoom(Vector2 NewPosition)
    {
        StartCoroutine(MoveToPosition(NewPosition));
    }
    IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        Vector3 startPosition = transform.position;

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
