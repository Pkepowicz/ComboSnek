using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneak : MonoBehaviour
{
    public Renderer rend;

    private Vector3 direction = Vector2.up;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        } 
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = transform.position + (direction * rend.bounds.size.x);
    }
}