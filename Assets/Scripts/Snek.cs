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


    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
        segments.Add(GameObject.FindWithTag("Player").transform);
        colors[0] = Color.red;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        randomizeColor();
        Debug.Log(direction);
        StartCoroutine(Move());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Up();
        } 
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Down();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
    }

    private IEnumerator Move()
    {
        while (true)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }
            direction = desired;
            transform.position = transform.position + direction;
            yield return new WaitForSeconds(GameManager.Instance.currentSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Food")
        {
            Color foodColor = collision.transform.GetComponent<Food>().color;
            Grow();
            if (foodColor == this.currentColor)
            {
                GameManager.Instance.SpeedUp();
                GameManager.Instance.AddTime();
                GameManager.Instance.AddPoints(5);
                randomizeColor();
            }
            else
            {
                GameManager.Instance.SpeedDown();
                GameManager.Instance.AddPoints(2);
            }
        }
        if (collision.tag == "Obstacle")
        {
            GameManager.Instance.GameOver();

        }
    }

    public void DeleteSnake()
    {
        foreach (Transform segment in segments)
        {
            Destroy(segment.gameObject);
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