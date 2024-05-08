using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class EnemyMotion : MonoBehaviour

{
    float distance = 5f;
    Color Color = Color.red;
    public LayerMask EnemyLayerMask, playerlayer;
    RaycastHit2D hit;
    Animator ani;
    float covdis;
    public float rometime = 2f;
    public float speed = 5f;
    public SpriteRenderer spriteRenderer;
    public Collider2D Collider2D;
    public float colliderRadius = 0.5f;
    public Transform pointradius;
    public Slider slider;
    public float maxhealth = 100, damage = 25;
    public static EnemyMotion instance;
    
    public enum movestate
    {
        enemy1_run,
        attack1,
        die
    }





    // Start is called before the first frame update
    private void Start()

    {
        ani = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (instance == null)
        {
            instance = this;
        }

    }

    // Update is called once per frame
    private void Update()
    {
       
        Collider2D[] player = Physics2D.OverlapCircleAll(pointradius.transform.position, colliderRadius, playerlayer);

        bool playerDetected = false;


        foreach (Collider2D collider in player)
        {
            if (collider.CompareTag("Player"))
            {
                //ani.SetInteger("State", 1);
                playerDetected = true;
                break;
            }
            
        }

        if (playerDetected)
        {
            ani.SetInteger("State", 1);
           
        }
        else
        {
            ani.SetInteger("State", 0);
        }

        if (maxhealth <= 0)
        {
            ani.SetInteger("State", 2);
        }





    }
    public void Enemyattack(float damage)
    {
        

        maxhealth -= damage;
        slider.value = maxhealth;

    }
    

    public void Attack()
    {
        print("Attack");
        playercontroller.instance.health(20);


    }
    //bool attack()
    //{
    //    return ani.SetInteger()
    //}

    void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(pointradius.transform.position, colliderRadius);
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.transform.gameObject.name == "Player")
    //    {
    //        Attack();

    //    }
    //}



    //public void Attack()
    //{
    //    Collider2D[] player = Physics2D.OverlapCircleAll(pointradius.transform.position, colliderRadius, playerlayer);


    //    foreach (Collider2D collider in player)
    //    {
    //        if (collider.CompareTag("Player"))

    //            print("Attack");
    //    }
    }








