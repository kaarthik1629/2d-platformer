using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour

{

    public float Speed = 2, jumpspeed = 7, MovementLerp = 2;
    public Transform Transform, CameraTransform;
    public Rigidbody2D Rigidbody2D;
    public Animator ani;
    public Vector3 camoff;
    float dirx;
    public LayerMask  Enemylayer, groundLayer, Enemylayer2;
    public Slider slider;
    
    public float colliderRadius = 0.5f, gcheckvalue = 0.1f;
    public Color gizmoscolor = Color.white;
    public Collider2D Collider2D;
    public Transform[] attackpoint;
    public Transform pointradius;
    public int maxhealth = 100;
    public int attackhealth = 20;
    public static playercontroller instance;
    

    public enum movement
    {
        idle,
        run,
        jump,
        attack,
        die
    }







    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic("Theme");
        ani = GetComponent<Animator>();
        

        if(instance == null)
        {
            instance = this;
        }


    }
    private void Update()
    {
        dirx = Input.GetAxis("Horizontal");
        //CameraTransform.position = new Vector3(transform.position.x + camoff.x, transform.position.y + camoff.y, -50 + camoff.z);
        transform.Translate(dirx * Speed * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded())
        {
            print("Space press");
            Rigidbody2D.velocity = new Vector3(Rigidbody2D.velocity.x, jumpspeed, 0f);
        }
        movements();

        


    }
    public void health (int damage)
    {
       
        maxhealth -=damage;
        slider.value = maxhealth;
        
        
    }
    public void movements()
    {
      

        movement state;
        if (dirx > 0)
        {
            Transform.localScale = new Vector3(1, 1, 1);

            state = movement.run;

        }
        else if (dirx < 0)
        {
            Transform.localScale = new Vector3(-1, 1, 1);
            state = movement.run;


        }
        else
        {
            state = movement.idle;
        }
        if (Rigidbody2D.velocity.y > 0.1f)
        {
            state = movement.jump;
        }


        if (Input.GetMouseButton(0))
        {
            state = movement.attack;
        }
        if (maxhealth <= 0)
        {
            state = movement.die;
          
        }
       
        ani.SetInteger("move", (int)state);

    }


    public void FixedUpdate()
    {

       



    }
    // Update is called once per frame
    private void OnDrawGizmos()

    {
        Gizmos.DrawWireSphere(CameraTransform.position + camoff, 0.5f);
        Gizmos.color = gizmoscolor;


        Gizmos.DrawWireSphere(pointradius.transform.position, colliderRadius);

    }

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(pointradius.transform.position, colliderRadius, Enemylayer);

        foreach (Collider2D collider in enemy)
        {
            
            if (EnemyMotion.instance != null)
            {
                EnemyMotion.instance.Enemyattack(25);
            }
            

           
        }

    }
    bool isGrounded()

    {
        return Physics2D.BoxCast(Collider2D.bounds.center, Collider2D.bounds.size,0, Vector2.down,0.1f, groundLayer);

       
    }





}
