using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;
    public float speed;
    public Rigidbody2D rb;
    public Vector2 movement;
    public GameObject target;
    public bool isControllabe = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isControllabe)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * speed;

            if (target != null || Input.GetKeyDown(KeyCode.E))
            {
                cam.tag = "Untagged";
                target.GetComponent<Task>().cam.tag = "MainCamera";
                isControllabe=false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Task")
        {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Task")
        {
            target = null;
        }
    }
}
