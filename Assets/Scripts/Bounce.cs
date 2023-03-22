using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField]
    private float force = 350f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0 && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);

            AudioManager.instance.PlaySFX("Jump");
        }
        if (collision.gameObject.CompareTag("Spring"))
        {
            transform.position = new Vector3(transform.position.x - 2f, transform.position.y, 0);
        }
        if (collision.gameObject.CompareTag("MovePlatform"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2f, 0);
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.position = new Vector3(transform.position.x - 2f, transform.position.y, 0);
        }
        if (collision.gameObject.CompareTag("BreakPlatform"))
        {
            transform.position = new Vector3(transform.position.x - 2f, transform.position.y, 0);
        }
    }


}
