using UnityEngine;
public class TrollMovement : MonoBehaviour
{
    private float velocityX;
    private Rigidbody2D rb;
    [SerializeField] private Transform body;
    [SerializeField] private TrollSo data;
    public bool inFloor = true;

    private void Start()
    {
        velocityX = data.velocityX;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = velocityX * 2;
    }


    public void ChangeDirection()
    {
        Debug.Log("Se cambio de direccion");
        Vector3 rotacion = body.transform.eulerAngles;
        if (Mathf.Approximately(rotacion.y, 180f))
        {
            rb.linearVelocityX = velocityX;
            body.transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Se cambio de direccion hacia la der");
        }
        else
        {
            rb.linearVelocityX = -velocityX;
            body.transform.rotation = Quaternion.Euler(0, 180, 0);
            Debug.Log("Se cambio de direccion hacia la izq");

        }
    }

    public void Stop()
    {
        rb.linearVelocityX = 0;
    }

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
