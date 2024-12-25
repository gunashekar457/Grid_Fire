using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private float move = 1f;
    public GameObject player;
    public GameObject bulletprefab;
    public Transform bulletposition;
    private float playerhealth = 100f;
    private float playercurrenthealth;
    public AudioSource shootsound;
    private void Start()
    {
        objectpool.instance.PlayerScript = this;


        playercurrenthealth = playerhealth;
    }








    // Update is called once per frame
    void Update()
    {
       // if (player.transform.position.x >= 0 && player.transform.position.x < 4)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //  checkpos();
                player.transform.position = player.transform.position + new Vector3(-move, 0f, 0f);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                // checkpos();
                player.transform.position = player.transform.position + new Vector3(move, 0f, 0f);
            }
            Vector3 currPos = transform.position;
            currPos.x = Mathf.Clamp(transform.position.x,0,4);
            transform.position = currPos;

        }
        if(Input.GetMouseButtonDown(0))
        {
            fire();
        }
        if(playercurrenthealth<=0)
        {
            Destroy(gameObject);
            Debug.Log("gameover");
            Time.timeScale = 0;
        }

        //void checkpos()
        //{

        //        if (player.transform.position.x < 0)
        //        {
        //            Vector2 pos = transform.position;
        //            pos.x = 0;
        //            transform.position = pos;
        //        }


        //        if (player.transform.position.x == 4)
        //        {
        //            player.transform.position = new Vector2(3, 0);
        //        }

        //}

    }
    public void fire()
    {
        GameObject bullet = objectpool.instance.getpooledobject();
        shootsound.Play();
        if(bullet!=null)
        {
            bullet.transform.position = bulletposition.position;
            bullet.SetActive(true);
        }

    }
    public void damageplayer(float playerdamage)
    {
        playercurrenthealth -= playerdamage;

    }
  
}
