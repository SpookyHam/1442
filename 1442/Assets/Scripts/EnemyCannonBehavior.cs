using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonBehavior : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject player;
    private Rigidbody2D rb;
    public float offset = 180f;
    public float speed = .7f;
    public float interval = 1f;
    public float damage = 3;
    public float lowerLimit = 10;
    

    private float timer;
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
       transform.position += new Vector3(0f,-0.4f,0f) * Time.deltaTime * speed; 
       
        // Cannon faces player
        Vector3 direction = player.transform.position - transform.position;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + offset);
        
        
        //Interval between shots
        timer += Time.deltaTime;

        if(timer > interval)
        {
            timer = 0;
            shoot();
        }

        //Despawn after going past bottom of screen
         if (transform.position.y < -lowerLimit)
    {
        Destroy(this.gameObject);
    }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Arrow")
        {
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }

        else if (whatIHit.tag == "Player")
        {
            whatIHit.GetComponent<PlayerHealth>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
