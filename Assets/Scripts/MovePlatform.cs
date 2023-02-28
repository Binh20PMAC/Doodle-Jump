using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]
    private float force = 300f;

    [SerializeField]
    private float move = 3f;

    private AudioSource saw;

    [SerializeField]
    private AudioClip jump;


    private Vector3 positonMove;
    private Vector3 dir;


    // Start is called before the first frame update

    private void Start()
    {
        positonMove = new Vector3(2.2f, transform.position.y, 0);
        dir = (positonMove - transform.position).normalized;
        saw = GameObject.FindObjectOfType<AudioSource>();

    }
    private void Update()
    {

        if (transform.position.x > 2.2f)
        {

            positonMove.x = transform.position.x;
            positonMove.x = -positonMove.x;
            dir = (positonMove - transform.position).normalized;
        }
        if (transform.position.x < -2.2f)
        {
            positonMove.x = transform.position.x;
            positonMove.x = -positonMove.x;
            dir = (positonMove - transform.position).normalized;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + dir.x, transform.position.y, 0), move * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
          
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);
            saw.PlayOneShot(jump);
        }
       
    }
}
