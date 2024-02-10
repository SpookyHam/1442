using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerArrowBehavior : MonoBehaviour
{
    public float arrowLimit = 11f;

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
            Destroy(this.gameObject);
        }
    }
}