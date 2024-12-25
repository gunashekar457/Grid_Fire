using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridmanager : MonoBehaviour
{
    public int height=10;
    public int width=5;
    [SerializeField]private GameObject tiles;
   
    public Color even, odd,C_temp;

    private Vector2 spawnpos;
    public Transform cam;

    int id = 0;
    public void Start()
    {
        genrategrid();
    }
    public void genrategrid()
    {
        for(int x=0;x<height; x++)
        {
          
            for(int y=0;y<width;y++)
            {
                id += 1;
                spawnpos = new Vector2(y, x);
                var GObj = Instantiate(tiles, spawnpos, Quaternion.identity);
                GObj.gameObject.name = " ID " + x.ToString() + " " + y.ToString();
                //changecolor();
                if (id % 2 == 0)
                {
                    GObj.GetComponent<SpriteRenderer>().color = even;

                }else{

                    GObj.GetComponent<SpriteRenderer>().color = odd;
                }
                 
            }
            id = 0;
            C_temp = even;
            even = odd;
            odd = C_temp;
            spawnpos += new Vector2(spawnpos.x, spawnpos.y + 0.2f);

        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
      
       
    }
   
  
            



}
