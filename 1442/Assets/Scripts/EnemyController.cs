using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float launchSpeed = 5f; // Speed at which the enemy is launched towards the player
    public float projectileSpeed = 10f; // Speed of the projectile
    public float spawnInterval = 1f; // Interval between each projectile spawn

    private Transform player; // Reference to the player's Transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player GameObject and get its Transform

        GetComponent<Rigidbody>().velocity = (player.position - transform.position).normalized * launchSpeed; // Apply launch velocity

        InvokeRepeating("ShootProjectile", spawnInterval, spawnInterval); // Start shooting projectiles with the specified interval
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity); // Instantiate a projectile
        Vector3 shootDirection = (player.position - transform.position).normalized; // Calculate the direction to shoot
        projectile.GetComponent<Rigidbody>().velocity = shootDirection * projectileSpeed; // Apply velocity to the projectile
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DespawnTrigger")) // Check if the enemy collides with an object tagged as "DespawnTrigger"
        {
            Destroy(gameObject); // Destroy the enemy GameObject
        }
    }
}
