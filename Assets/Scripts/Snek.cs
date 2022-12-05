using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    public Renderer rend;
    
    private Vector3 direction = Vector2.up;
    private Vector3 desired = Vector2.up;
    private List<Transform> segments;
    public Transform segmentPrefab;
    private Color currentColor;
    private Color[] colors = new Color[3];
    public GameObject foodEatenEffect;

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
        colors[0] = Color.red;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        randomizeColor();
        Debug.Log(direction);
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

        direction = desired;
        Move();
    }

    private void Move()
    {
        transform.position = transform.position + direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Color foodColor = collision.transform.GetComponent<Food>().color;
            GameManager.Instance.AddPoints(1);
            /*GameObject currentEffect = Instantiate(foodEatenEffect, transform.position, Quaternion.identity);
            Debug.Log(currentEffect.transform.position);
            var main = currentEffect.GetComponent<ParticleSystem>().main;
            main.startColor = foodColor;
            main.startLifetimeMultiplier = GameManager.Instance.TimeModification();
            */
            Grow();
            if (foodColor == this.currentColor)
            {
                GameManager.Instance.SpeedUp();
                GameManager.Instance.AddTime();
                randomizeColor();
            }
            else GameManager.Instance.SpeedDown();
        }
        if (collision.tag == "Obstacle")
        {
            foreach (Transform segment in segments)
            {
                Destroy(segment.gameObject);
            }
            //GameOver();
            GameManager.Instance.GameOver();
            

        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segment.localScale = transform.lossyScale;
        segments.Add(segment);  
    }

    private void randomizeColor()
    {
        currentColor = colors[Random.Range(0, 3)];
        this.transform.GetComponent<SpriteRenderer>().color = currentColor;
    }

    /*private void GameOver()
    {
        transform.position = new Vector3(-100, -100, -100);
        Time.timeScale = 0;
    }*/

    public void Up()
    {
        if (direction != Vector3.down) desired = Vector2.up;
    }

    public void Down()
    {
        if (direction != Vector3.up) desired = Vector2.down;
    }    

    public void Left()
    {
        if (direction != Vector3.right) desired = Vector2.left;
    }

    public void Right()
    {
        if (direction != Vector3.left) desired = Vector2.right;
    }
}