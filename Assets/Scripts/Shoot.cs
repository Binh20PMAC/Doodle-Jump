using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    private Vector3 vector3 = Vector3.zero;
    private List<GameObject> bulletPool = new List<GameObject>();
    private int nextBulletIndex = 0;
    private float last;
    private void Start()
    {
        vector3.y += 0.1f;

        // Create bullet pool
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
    private void Update()
    {
        transform.position = player.transform.position + vector3;
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the direction from the player's position to the mouse cursor's position in the world space
            Vector3 shootDirection = Vector3.Normalize(mousePosition - transform.position);

            // Calculate the angle of rotation for the player's transform based on the direction of the mouse cursor
            float shootAngle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg - 90f; // Randian to degrees - 90 degrees
            float rotation = Mathf.Clamp(shootAngle, -20f, 20f); // Limit z-axis

            // Set the rotation of the player's transform to the calculated rotation angle around the z-axis
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
            Debug.Log(Time.time - last);
            if (Time.time - last < 0.2f) // Delay bullet
            { return; }
            last = Time.time;

            // Get bullet from pool
            GameObject bullet = GetNextBulletFromPool();
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 15f;
        }
    }
    private GameObject GetNextBulletFromPool()
    {
        GameObject bullet = bulletPool[nextBulletIndex];
        nextBulletIndex = (nextBulletIndex + 1) % 4;
        return bullet;
    }


}
