
using UnityEngine;


public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject BackgroundGameOver;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            BackgroundGameOver.SetActive(true);
        }
    }


}

