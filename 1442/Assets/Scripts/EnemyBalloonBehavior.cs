using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBalloonBehavior : MonoBehaviour
{
     public GameObject bomb;
    public Transform bombPos;
    public GameObject player;
    private Rigidbody2D rb;
    public float speed = .3f;
    private float timer;
    public float damage = 2;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //movement
        transform.Translate(new Vector3(0f, -0.5f, 0f) * Time.deltaTime * speed);

        // Interval between shots
         timer += Time.deltaTime;

          if(timer > 1)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bomb, bombPos.position, Quaternion.identity);
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
