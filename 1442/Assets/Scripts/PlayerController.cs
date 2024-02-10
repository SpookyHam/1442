using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float speed;
    public float horizontalScreenLimit = 9.5f;
    public float verticalScreenLimit = 4f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * speed);

        // If x position is greater than horizontal screen limit, stop there
        if (transform.position.x > horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }
        // If x position is less than horizontal screen limit, stop there
        else if (transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        // If y position if greater than vertical screen limit, stop there
        if (transform.position.y >= verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimit, 0);
        }
        //If y position is less than vertical screen limit, stop there
        else if (transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }
    }

    void Shooting()
    {
        // Fire arrow when spacebar is pressed
        if (Input.GetKeyDown("space"))
        {
            //Create arrow
            Instantiate(arrowPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}