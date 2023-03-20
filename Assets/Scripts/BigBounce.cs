using UnityEngine;

public class BigBounce : MonoBehaviour
{
    [SerializeField]
    private float force = 450f;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);

            AudioManager.instance.PlaySFX("Spring");

        }

    }
}
