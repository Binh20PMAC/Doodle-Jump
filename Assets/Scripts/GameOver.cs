using UnityEngine;


public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform playerGameOver;
    [SerializeField]
    private GameObject BackgroundGameOver;

    private void Update()
    {
        if (player.localScale.x < 0)
        {
            playerGameOver.localScale = new Vector2(-384, playerGameOver.localScale.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            BackgroundGameOver.SetActive(true);
        }
        Vector2 tempPlayer = player.position;
        playerGameOver.position = new Vector2(tempPlayer.x, tempPlayer.y + 15f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BackgroundGameOver.SetActive(true);
        }
        Vector2 tempPlayer = player.position;
        playerGameOver.position = new Vector2(tempPlayer.x, tempPlayer.y + 15f);
    }
}

