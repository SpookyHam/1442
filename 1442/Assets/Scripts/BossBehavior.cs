using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
  public GameObject bullet;
    public Transform bulletPos1;
    public Transform bulletPos2;
    public GameObject bomb;
    public Transform bombPos1;
    public Transform bombPos2;
    public GameObject player;
    private Rigidbody2D rb;
    public float offset = 180f;
    public float speed = .7f;
    public float interval1 = 1f;
    public float interval2 = 3f;
    public float damage = 5;
    public float lowerLimit = 10;
    public float horizontal = 0f;
    public float vertical = -0.4f;
    public float bossHealth = 50f;
    

    private float timer1;
    private float timer2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
       //Movement
       transform.position += new Vector3(horizontal,vertical,0f) * Time.deltaTime * speed; 
       
        
        //Interval between cannon shots
        timer1 += Time.deltaTime;

        if(timer1 > interval1)
        {
            timer1 = 0;
            shootCannons();
        }

        //Interval between bomb shots
        timer2 += Time.deltaTime;

        if(timer2 > interval2)
        {
            timer2 = 0;
            shootBombs();
        }

        //Despawn after going past bottom of screen
         if (transform.position.y < -lowerLimit)
        {
            Destroy(this.gameObject);
        }

        //Destroy after losing all health
        if (bossHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void shootCannons()
    {
        Instantiate(bullet, bulletPos1.position, Quaternion.identity);
        Instantiate(bullet, bulletPos2.position, Quaternion.identity);
    }

    void shootBombs()
    {
        Instantiate(bomb, bombPos1.position, Quaternion.identity);
        Instantiate(bomb, bombPos2.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Arrow")
        {
            Destroy(whatIHit.gameObject);
            bossHealth -= 1f;
           
        }

        else if (whatIHit.tag == "Player")
        {
            whatIHit.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
