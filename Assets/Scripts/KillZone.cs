using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public float Damage = 100f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (PlayerControl.PlayerInstance != null)
        {
            PlayerControl.Health -= Damage * Time.deltaTime;
        }
    }
}
