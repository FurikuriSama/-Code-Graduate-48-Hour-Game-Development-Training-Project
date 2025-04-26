using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator ani;
    bool isNearDoor = false;
    bool doorIsOpen = false;
    public GameObject DoorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNearDoor)
        {
            doorIsOpen = !doorIsOpen; // 切换门的开关状态
            ani.SetBool("dooropen", doorIsOpen);
        }
    }

    // 检测玩家是否接近门
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearDoor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearDoor = false;
        }
    }
}
