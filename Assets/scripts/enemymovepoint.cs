using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class enemymovepoint : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentpoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentpoint = pointB.transform;
        anim.SetBool("isrunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentpoint.position - transform.position;
        if (currentpoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed,0);

        }
        else 
        {

            rb .velocity = new Vector2(-speed,0);
        }
        if (Vector2.Distance(transform.position,currentpoint.position) < 0.5 && currentpoint == pointB.transform) 
        {
          
            currentpoint = pointA.transform;

        }
        if (Vector2.Distance (transform.position,currentpoint.position) < 0.5 && currentpoint == pointA.transform) 
        {
            currentpoint = pointB.transform;
        }
    }
}
