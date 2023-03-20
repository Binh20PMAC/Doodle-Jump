using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
  
    private Rigidbody2D rb;

    [SerializeField]
    private float moveInput;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private TMP_Text highscoreText;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public float topScore = 0f;
    public float topHighScore = 0f;

    private float LeftX;
    private float RightX;

    public static PlayerController instance;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        topHighScore = PlayerPrefs.GetFloat("HighScore", 0);
 
        highscoreText.text = "High Score: " + topHighScore.ToString();
        scoreText.text = "Score: " + topScore.ToString();

        rb = GetComponent<Rigidbody2D>();

        LeftX = ((float)Screen.width / (float)Screen.height) * (-5);
        RightX = ((float)Screen.width / (float)Screen.height) * (5);
    }

 

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal"); // A and D are left, right keys 
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        AddPoint();

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


        if(transform.position.x > RightX)
        {
            Vector2 XPlayer = transform.position;
            XPlayer.x = LeftX;
            transform.position = XPlayer;
        }
        else if(transform.position.x < LeftX)
        {
            Vector2 XPlayer = transform.position;
            XPlayer.x = RightX;
            transform.position = XPlayer;
        }
       
    }

    public void AddPoint ()

    {
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        highscoreText.text = "High Score: " + Mathf.Round(topHighScore).ToString();

        if (topHighScore < topScore)
            PlayerPrefs.SetFloat("HighScore", topScore);  
    }
  
   
}

 
  
