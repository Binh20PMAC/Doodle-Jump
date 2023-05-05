using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject boss;
    [SerializeField] float moveSpeed = 2.0f;
    int direction = 1;
    float tempDirection;
    private void Start()
    {
        tempDirection = transform.position.x;
    }
    void Update()
    {
        transform.Translate(new Vector2(moveSpeed * direction * Time.deltaTime, 0));
        if (transform.position.x < tempDirection - 0.5f)
        {
            direction = 1;
        }
        else if (transform.position.x > tempDirection + 0.5f)
        {
            direction = -1;
        }

        if (!boss.activeInHierarchy)
        {
            SpawnBoss();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Destroy"))
        {
            boss.SetActive(false);
            AudioManager.instance.StopSFX("Monster");
        }

        if (collision.gameObject.CompareTag("Limit"))
        {
            AudioManager.instance.PlaySFX("Monster");
        }    

    }

    private void SpawnBoss()
    {
        float playerX = Random.Range(-2.6f, 2.6f);
        float playerY = player.position.y + Random.Range(50f, 100f);
        Vector2 space = new Vector2(playerX, playerY);
        gameObject.transform.position = space;
        boss.SetActive(true);
    }
}
