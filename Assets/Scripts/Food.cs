using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //public BoxCollider2D gridArea;
    public Color color;
    private AudioSource sound;

    private void Start()
    {
        RandomizePosition();
        //this.transform.GetComponent<SpriteRenderer>().color = color;
        sound = this.transform.GetComponent<AudioSource>();
    }

    private void RandomizePosition()
    {
        //Bounds bounds = gridArea.bounds;
        float x, y;
        int i = 0;
        while (true)
        {
            i += 1;
            x = Random.Range(-11, 11);
            y = Random.Range(-6, 20);
            if(!Physics2D.OverlapCircle(new Vector2(x, y), 0.8f)) break;
            if (i > 15)
            {
                transform.position = new Vector3(-200, -200, -200);
                break;
            }
        }
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sound.Play();
            RandomizePosition();
        }
    }
}
