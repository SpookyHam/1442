using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false; // Disable gravity for the projectile
    }

    void Update()
    {
        // Check if the projectile is out of the screen boundaries
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject); // Destroy the projectile if it's not visible on the screen
        }
    }
}
