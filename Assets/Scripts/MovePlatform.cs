
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]
    private float force = 350f;

    [SerializeField]
    private float moveSpeed = 3f;
    private int direction = 1;

    private void Update()
    {
        transform.Translate(new Vector2(moveSpeed * direction * Time.deltaTime, 0));
        if (transform.position.x < -2.5f)
        {
            direction = 1;
        }
        else if (transform.position.x > 2.5f)
        {
            direction = -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);
            AudioManager.instance.PlaySFX("Jump");
        }
    }
}
