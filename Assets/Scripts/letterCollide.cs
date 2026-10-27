using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player1")
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        // Destruir el objeto cuando ya no es visible
        Destroy(gameObject);
    }
}
