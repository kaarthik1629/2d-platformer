using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class EnemyMotion : MonoBehaviour

{
    float distance = 5f;
    Color Color = Color.red;
    public LayerMask EnemyLayerMask, playerlayer;
    RaycastHit2D hit;
    Animator ani;
    public float rometime = 2f;
    public float speed = 5f;
    public SpriteRenderer spriteRenderer;
    public Collider2D Collider2D;
    public float colliderRadius = 0.5f;
    public Transform pointradius;
    private Slider slider;
    public float maxhealth = 100, damage = 25;
    public static EnemyMotion instance;
    public GameObject original;
    public GameObject position ;
    public bool isEnemyAlive;
    public int poolsize = 5;
    private List<GameObject> pooledEnemies= new List<GameObject>();
    private float currenthealth;

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
        slider = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Slider>();  

        if (instance == null)
        {
            instance = this;
        }
        
    }
         /*void start ()
         {
             for (int i = 0; i < poolsize; i++)
             {
                 GameObject enemy = Instantiate(original, Vector3.zero, Quaternion.identity);
                 enemy.SetActive(false);
                 polledEnemies.Add(enemy);
             }
         }

         public GameObject GetpolledEnemies()

         { 
             foreach (GameObject enemy in pooledEnemies)


             {
             print("into the for loop");
                 if (!enemy.activeInHeirarchy)
                 {
                     print("into the If condition");
                     enemy.SetActive(true);
                     return enemy;
                 }
                 //GameObject NewObject = Instantiate(original, position.transform.position, Quaternion.identity);
                 //isEnemyAlive = true;    
             }

         }
             GameObject nowEnemy = Instantiate(original, Vector3.zero,Quaternion.identity);
             polledEnemies.Add(newEnemy);
             return newEnemy;*/



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
                gameObject.SetActive(false);

            }





        }
        public void Enemyattack(float damage)
        {
           
       
            currenthealth -= damage;
            slider.value = currenthealth;

        }


       /* public void Attack()
        {
            print("into the enemy attack");

           playercontroller.instance.health(1);
        }*/
       

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









