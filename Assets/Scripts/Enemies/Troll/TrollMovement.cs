using UnityEngine;
public class TrollMovement : MonoBehaviour
{
    private float velocityX;
    private Rigidbody2D rb;
    [SerializeField] private Transform body;
    [SerializeField] private TrollSo data;
    // Warning: Campo public mutable que nadie lee. Borralo o pasalo a private.
    public bool inFloor = true;

    private void Start()
    {
        velocityX = data.velocityX;
        rb = GetComponent<Rigidbody2D>();
        // Bug: El troll arranca a velocityX * 2 y después de ChangeDirection/Continue pasa a velocityX: la velocidad inicial no coincide
        // con la del SO. Usá el mismo valor en los tres lugares.
        rb.linearVelocityX = velocityX * 2;
    }


    public void ChangeDirection()
    {
        // Suggestion: Variable local en español ('rotacion'). Todo el código va en inglés (pauta P4): rotation. Lo mismo en Continue().
        Vector3 rotacion = body.transform.eulerAngles;
        if (Mathf.Approximately(rotacion.y, 180f))
        {
            rb.linearVelocityX = velocityX;
            body.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            rb.linearVelocityX = -velocityX;
            body.transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }

    public void Stop()
    {
        rb.linearVelocityX = 0;
    }

    // Suggestion: Continue() y ChangeDirection() repiten el mismo bloque de asignación de velocidad y rotación. Extraé un método SetDirection(bool right).
    public void Continue()
    {
        Vector3 rotacion = body.transform.eulerAngles;
        if (Mathf.Approximately(rotacion.y, 0f))
        {
            rb.linearVelocityX = velocityX;
            body.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            rb.linearVelocityX = -velocityX;
            body.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
