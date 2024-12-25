using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class wave
{
    public string waveName;
    public int noofenemies;
    public GameObject[] typeofenemies;
    public float spawninterval;

}

public class spawningmanager : MonoBehaviour
{
    public GameObject player;
    public wave[] waves;
    private wave currentwave;
    private int currentwavenum;
    private float spawntime;
    private bool canspawn = true;
    private bool cananimate=false;
    public gridmanager gm;
    public Animator anim;
    public Text nextwave;
   
    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gridlayout").GetComponent<gridmanager>();
        spawnplayer();
       
       
    }
    private void Update()
    {
        currentwave = waves[currentwavenum];
        spawnwave();
        GameObject[] toatalenemy = GameObject.FindGameObjectsWithTag("enemy");
        if(toatalenemy.Length==0 )
        {
            if ( currentwavenum + 1 != waves.Length )
            {
                if(cananimate)
                {
                    Debug.Log("hi");
                    nextwave.text = waves[currentwavenum + 1].waveName;
                    anim.SetTrigger("wavecomplete");
                    cananimate = false;
                }
               
            }
            else
            {
                Debug.Log("game Finished");
            }


        }
       
    }
    public void spawnnextwave()
    {
        currentwavenum++;
        canspawn = true;
    }
    public void spawnwave()
    {
        if(canspawn && spawntime<Time.time)
        {
            int startile = gm.height - 1;
            int ranum = Random.Range(0, gm.width);
            GameObject randomenemy = currentwave.typeofenemies[Random.Range(0, currentwave.typeofenemies.Length)];
            Instantiate(randomenemy, new Vector3(ranum, startile, 0f), Quaternion.identity);
            currentwave.noofenemies--;
            spawntime = Time.time+currentwave.spawninterval;
            if(currentwave.noofenemies == 0)
            {
                canspawn = false;
                cananimate = true;
            }

        }
       

        
    }
    public void spawnplayer()
    {
        int startile = gm.height - gm.height;
        int ranum = Random.Range(0, gm.width);
        Instantiate(player, new Vector3(ranum, startile, 0f), Quaternion.identity);
    }
}
