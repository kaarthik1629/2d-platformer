using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fall : MonoBehaviour

{
    
    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        
      
        

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( (collision != null && collision.gameObject == Player))
            {
                print("fall");
                playercontroller.instance.health(100);

            
        }
        
    }
     


}

