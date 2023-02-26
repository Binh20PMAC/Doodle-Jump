using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveInput;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float topScore = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal"); // A and D are left, right keys 
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();

        if(transform.position.x > 2.7f)
        {
            Vector2 XPlayer = transform.position;
            XPlayer.x = -2.7f;
            transform.position = XPlayer;
        }
        else if(transform.position.x < -2.7f)
        {
            Vector2 XPlayer = transform.position;
            XPlayer.x = 2.7f;
            transform.position = XPlayer;
        }

       
    }
}

 
  
