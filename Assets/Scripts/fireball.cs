using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    private int fireballdamage = 20;
    public Rigidbody2D rb;
    Vector2 screenbonds;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target.x = transform.position.x;
        target.y = 0f;
        target.z = transform.position.z;
        screenbonds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        rb = rb.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * 5f;

        if (transform.position.y < -5)
        {

            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            objectpool.instance.PlayerScript.damageplayer(fireballdamage);
            gameObject.SetActive(false);
        }

    }
}
