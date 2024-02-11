using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
   public GameObject blast;
   public Transform blastPos;
   public float damage = 5;
   
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(this.gameObject, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Cannon")
        {
            Destroy(whatIHit.gameObject);
            
        }

        else if(whatIHit.tag == "Balloon")
        {
            Destroy(whatIHit.gameObject);
        }

        else if(whatIHit.tag == "Boss")
        {
            whatIHit.GetComponent<BossBehavior>().bossHealth -= damage;
        }

        

      
    }
}