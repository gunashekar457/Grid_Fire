using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemymovement : MonoBehaviour
{
    private float enemyhealth = 100f;
    private float currenthealth;
    public gridmanager gm;
    public Vector2 starttile;
    private float enemydamage = 30f;//enemy damaging player
    private Slider healthSlider;
    public ParticleSystem heal;
   
   


    float Timer = 2f;
    public void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("gridlayout").GetComponent<gridmanager>();
        //healthbar=GameObject.FindGameObjectWithTag("enemy").GetComponent<Slider>();
        
      

    }

    private void Start()
    {
        currenthealth = enemyhealth;

        // Get slider component from the child of this object
        healthSlider = GetComponentInChildren<Slider>();
        if (healthSlider != null)
        {
            healthSlider.maxValue = enemyhealth;
            healthSlider.value = enemyhealth;
        }
    
    //Slider healthbar = gameObject.GetComponent<Slider>(); 

    currenthealth = enemyhealth;
        //objectpool.instance.health.sethealth(currenthealth, enemyhealth);
        //sethealth(currenthealth, enemyhealth);
        
        starttile.y = 0;
        
    }

    private void Update()
    {
        //sethealth(currenthealth, enemyhealth);


        // objectpool.instance.health.sethealth(currenthealth, enemyhealth);
        if (Timer < 0)
        {
            gameObject.transform.position += new Vector3(0f, -1f, 0f);

            Timer = 2f;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
        if(currenthealth<=0)
        {
            Destroy(gameObject);
        }
        
        if (transform.position.y == starttile.y)
        {
            Destroy(gameObject);
            Debug.Log(transform.position.y);
            Debug.Log(starttile.y);
            objectpool.instance.PlayerScript.damageplayer(enemydamage);
           // gameObject.GetComponent<playermovement>().damageplayer(enemydamage);

        }

    }
    public void damageenemy(float damage)
    {
        currenthealth -= damage;
        UpdateHealthBar();
       
    }
    public void takehealing(float damage)
    {
        if(currenthealth<100 && currenthealth!=100)
        {
            currenthealth += damage;
            heal.Play();
          
            Debug.Log(currenthealth);

        }
        UpdateHealthBar() ;
       
    }
    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currenthealth;
        }
    }
    //public void damageplayer()
    //{
    //    if (transform.position.y == starttile.y)
    //    {
    //        Debug.Log(transform.position.y);
    //        Debug.Log(starttile.y);
    //        gameObject.GetComponent<playermovement>().damageplayer(enemydamage);

    //    }

    //}
    //public void sethealth(float currhealth, float maxhealth)
    //{
    //   healthbar.enabled = true;
    //    healthbar.value = currhealth;
    //    healthbar.maxValue = maxhealth;
    //    fill.color = Color.Lerp(low, high, (float)healthbar.value / maxhealth);
    //}


}
