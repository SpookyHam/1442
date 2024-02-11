using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrowBehavior : MonoBehaviour
{
    public float arrowLimit = 6f;
   public GameObject blast;
   public Transform blastPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 8f);
    

    if (transform.position.y > arrowLimit || transform.position.y < -arrowLimit)
    {
        Instantiate(blast, blastPos.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    }

         void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Balloon") || other.gameObject.CompareTag("Cannon"))
        {
            Instantiate(blast, blastPos.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
