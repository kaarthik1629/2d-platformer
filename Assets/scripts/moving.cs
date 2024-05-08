using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moving : MonoBehaviour
{
    
    public Transform[] points;
    int counter = 0;
    float speed = 2f;
    SerializeField enemytransform;
    public GameObject Enemy;
    float rotationy = 180f;
    

    // Start is called before the first frame update
    void Start()
    {
        print(points.Length);
    }

    

    private void Update()

    {
        print("Counter Value = "+ counter);
        if(Vector3.Distance(transform.position, points[counter].position) < 0.1f)
        {
            print("First If");
            counter++;
            if(CompareTag("Enemy")) 
            {
                Enemy.transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
            }

        }

        if(counter >= points.Length)
        {
            print("secpond If");
            counter = 0;
            if (CompareTag("Enemy"))
            {
                print("third If");
                Enemy.transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);
            }                      
        }
        print("before the move toward function");
        transform.position = Vector3.MoveTowards(transform.position, points[counter].position, speed * Time.deltaTime);


        
        
    }

    private void print(Vector3 position1, Vector3 position2)
    {
        throw new NotImplementedException();
    }
}





    


