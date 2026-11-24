using System.Collections;
using UnityEngine;
public class TrollAttack : MonoBehaviour
{
    // Suggestion: 'atacking' y 'animato' tienen errores de tipeo (attacking, animator).
    private bool atacking = false;
    [SerializeField] private TrollMovement movement;
    [SerializeField] private Animator animato;
    [SerializeField] private GameObject attackHitBox;
    [SerializeField] private AudioSource attackSFX;
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Warning: String mágico "Player" y comparación con == false. Usá una const y !attacking.
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && atacking == false)
        {
            // Bug: El ataque no consulta si el troll está muriendo. Durante los 0.6 s de HealthComponent.Die() puede iniciar
            // Attack() y al terminar llama movement.Continue(), así que el troll muerto vuelve a caminar hasta destruirse.
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        movement.Stop();
        animato.Play("Attack");
        atacking = true;
        // Suggestion: Tiempos 0.3f, 0.2f, 0.2f mágicos. Llevalos a TrollSo.
        yield return new WaitForSeconds(0.3f);
        attackSFX.Play();
        yield return new WaitForSeconds(0.2f);
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackHitBox.SetActive(false);
        atacking = false;
        movement.Continue();
    }
}
