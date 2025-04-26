using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class tip : MonoBehaviour
{
    public SpriteRenderer _tip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _tip.enabled = true;
        }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _tip.enabled = false;
        }
    }

}
