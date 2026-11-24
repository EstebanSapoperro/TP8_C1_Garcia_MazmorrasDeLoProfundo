using UnityEngine;

public class TrollMovementRayCast : MonoBehaviour
{
    [SerializeField] private TrollMovement enemy;
    [SerializeField] private bool collitionChangeDirection;


    // Warning: OnTriggerExit2D/OnTriggerEnter2D no filtran por capa: cualquier collider que entre o salga (jugador, pickups, otro troll)
    // hace girar al enemigo. Depende solo de la matriz de colisiones. Filtrá con un LayerMask serializado.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collitionChangeDirection == false)
        {
            enemy.ChangeDirection();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collitionChangeDirection == true)
        {
            enemy.ChangeDirection();
        }
    }
}
