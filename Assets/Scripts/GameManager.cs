using UnityEngine;

// Suggestion: Es un MonoBehaviour que no está en ninguna escena y solo tiene estáticos. Hacelo static class o un SO de estado de partida.
public class GameManager : MonoBehaviour
{
    // Bug: currentRoom y currentKeys son static y nunca se reinician. Si el jugador agarra la llave, muere y toca Retry,
    // arranca la nueva partida con currentKeys = 1 y currentRoom del cuarto anterior. Reseteálos al cargar Gameplay.
    static public int currentRoom = 0;
    static public int currentKeys = 0;
}
