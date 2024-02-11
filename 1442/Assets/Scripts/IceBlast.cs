using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IceBlast : MonoBehaviour
{
   public GameObject blast;
   public Transform blastPos;
   
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(this.gameObject, .25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Cannon")
        {
            whatIHit.GetComponent<EnemyCannonBehavior>().interval *= 2f;
            whatIHit.GetComponent<EnemyCannonBehavior>().speed *= .5f;
            whatIHit.GetComponent<SpriteRenderer>().color = Color.blue;
            Destroy(this.gameObject);
        }

        else if(whatIHit.tag == "Balloon")
        {
            whatIHit.GetComponent<EnemyBalloonBehavior>().interval *= 2f;
            whatIHit.GetComponent<EnemyBalloonBehavior>().speed *= .5f;
            whatIHit.GetComponent<SpriteRenderer>().color = Color.blue;
            Destroy(this.gameObject);
        }

        

      
    }
}
