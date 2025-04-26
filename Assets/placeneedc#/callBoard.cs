using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callBoard: MonoBehaviour
{
    private Transform player;
    bool cantouch;
    bool istouched;
    private void Start()
    {
        istouched = false;
        Debug.Log("1");
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (cantouch && !istouched) 
            {
                istouched=true;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            cantouch = true;
            Debug.Log(cantouch);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            cantouch = false;
            Debug.Log(cantouch);
        }
    }
}
