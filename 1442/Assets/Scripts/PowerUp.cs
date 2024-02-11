using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp: MonoBehaviour
{

    public bool iceBoost;
    public bool fireBoost;
    public float speed = .5f;

    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, -0.5f, 0f) * Time.deltaTime * speed);
    }
}
