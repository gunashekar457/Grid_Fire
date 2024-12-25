using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwerenemy : MonoBehaviour
{
    public GameObject bullet;
    public float fireballdamage = 5f;
    public GameObject target;
    public Transform bulletposition;
    public gridmanager gm;
   
    float Timer = 1.5f;


    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gridlayout").GetComponent<gridmanager>();
       
       

    }
    public void Update()
    {
        if (Timer< 0)
        {
      
            firebullet();

            Timer = 2f;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
        //    if (currenthealth <= 0)
        //    {
        //        Destroy(gameObject);
        //    }

        //    if (transform.position.y == starttile.y)
        //    {
        //        Destroy(gameObject);
        //        Debug.Log(transform.position.y);
        //        Debug.Log(starttile.y);
        //        objectpool.instance.PlayerScript.damageplayer(enemydamage);
        //        // gameObject.GetComponent<playermovement>().damageplayer(enemydamage);

        //    }


    }
    public void firebullet()
    {
        GameObject bullet = objectpool.instance.getobjectpool();
        if (bullet != null)
        {
            bullet.transform.position = bulletposition.position;
            bullet.SetActive(true);
        }

    }
   
    //public void damageenemy(float damage)
    //{
    //    currenthealth -= damage;
    //}
}