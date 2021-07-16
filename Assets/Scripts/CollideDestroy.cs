using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDestroy : MonoBehaviour
{
    public string TagCompare = string.Empty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (string.IsNullOrEmpty(collision.tag) || string.IsNullOrEmpty(collision.tag) && !collision.CompareTag(TagCompare))
            return;

        Destroy(gameObject);
    }
}
