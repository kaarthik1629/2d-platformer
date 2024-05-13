using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypool : MonoBehaviour
{
    public static enemypool instance;
    public float spawnRate = 2f; 
    public float nextSpawnTime = 0f;
    public enemypool enemyPool;

    public List<GameObject> pooledobjects = new List<GameObject>();
    public int amounttopool = 5;

    [SerializeField] public GameObject enemyprefab;


    private void Awake()
    {
        if (instance == null)   
        {
            instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amounttopool ; i++)
        {
            GameObject obj = Instantiate(enemyprefab);
            obj.SetActive(false);
            pooledobjects.Add(obj);
        }
    }

    public GameObject Getpooledobjects()
    {
        for(int i = 0;i < pooledobjects.Count; i++)
        {
            if (!pooledobjects[i].activeInHierarchy)
            {
                return pooledobjects[i];

            }
        

        }
        return null;
    }
    public void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            GameObject newEnemy = enemyPool.Getpooledobjects();
            if (newEnemy != null)
            {
                newEnemy.transform.position = transform.position; 
                newEnemy.SetActive(true);
                nextSpawnTime = Time.time + spawnRate;
            }
        }
    }
}


