using System.Collections;
using UnityEngine;
public class TrollAttack : MonoBehaviour
{
    private bool atacking = false;
    [SerializeField] private TrollMovement movement;
    [SerializeField] private Animator animato;
    [SerializeField] private GameObject attackHitBox;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && atacking == false)
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        movement.Stop();
        animato.Play("Attack");
        atacking = true;
        Debug.Log("Se prepara para atacar");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("ataca");
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackHitBox.SetActive(false);
        atacking = false;
        movement.Continue();
    }
}
