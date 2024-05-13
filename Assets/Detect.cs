using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public GameObject Player;
    public static Detect Instance;
    public Rigidbody2D spikeRigidbody;
    public GameObject spike;

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

        if ( collision != null && collision.gameObject == Player ) 
        {
            print("detected player");
            spikeRigidbody.gravityScale = 1;

        }
        
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject == spike)
        {
            Destroy(spike.gameObject);
            print("enter");
            gameObject.SetActive(false);
        }
    }
}
