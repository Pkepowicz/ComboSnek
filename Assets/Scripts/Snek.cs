using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    public Renderer rend;

    private Vector3 direction = Vector2.up;
    private List<Transform> segments;
    public Transform segmentPrefab;

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    // Update is called once per frame
    private void Update()
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

    private void FixedUpdate()
    {
        for(int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        Move();
    }

    private void Move()
    {
        transform.position = transform.position + (direction * rend.bounds.size.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
        if (collision.tag == "Obstacle")
        {
            GameOver();
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segment.localScale = transform.lossyScale;
        segments.Add(segment);  
    }

    private void GameOver()
    {
        transform.position = new Vector3(-100, -100, -100);
        Time.timeScale = 0;
    }
}