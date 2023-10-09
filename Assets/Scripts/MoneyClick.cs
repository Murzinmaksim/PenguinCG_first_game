using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyClick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Wall wall = collision.GetComponent<Wall>();
        if (wall != null)
        {
            Destroy(gameObject);
        }
    
    }
}
