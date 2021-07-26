using UnityEngine;

public class TriggerAnimator : MonoBehaviour
{
    public Animator TriggerAnim = null;
    public string AnimBoolean = string.Empty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        TriggerAnim.SetBool(AnimBoolean, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        TriggerAnim.SetBool(AnimBoolean, false);
    }
}
