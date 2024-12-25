using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private int bulletdamage = 20;
   public Rigidbody2D rb;
    private float speed = 24f;
   
    Vector2 screenbonds;
    // Start is called before the first frame update
    void Start()
    {
        screenbonds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        rb = rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * speed;
        if(transform.position.y >screenbonds.y)
        {

            gameObject.SetActive(false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            collision.gameObject.GetComponent<enemymovement>().damageenemy(bulletdamage);
            
            gameObject.SetActive(false);
        }
    }
}
