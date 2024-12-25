using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpool : MonoBehaviour
{
    public static objectpool instance;
    private List<GameObject> pooledobjects = new List<GameObject>();
    private List<GameObject> objects = new List<GameObject>();
    private int amounttopool = 5;
    private int fireballamounttopool = 20;
    [SerializeField] private GameObject bulletprefab,fireballprefab;
   // public healthbarmanager health;


    public playermovement PlayerScript;
   
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update

    void Start()
    {
        for(int i=0;i<=amounttopool;i++)
        {
            GameObject obj = Instantiate(bulletprefab);
            obj.SetActive(false);
            pooledobjects.Add(obj);
        }
        for (int i = 0; i <= fireballamounttopool; i++)
        {
            GameObject obj = Instantiate(fireballprefab);
            obj.SetActive(false);
            objects.Add(obj);
        }

    }
    public void Update()
    {
        
    }

    public GameObject getpooledobject()
    {
        for(int i=0;i<=pooledobjects.Count;i++)
        {
            if (!pooledobjects[i].activeInHierarchy)
            {
                return pooledobjects[i];
            }
        }
        return null;
        
    }
    public GameObject getobjectpool()
    {
        for (int i = 0; i <= objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }
        return null;

    }
}
