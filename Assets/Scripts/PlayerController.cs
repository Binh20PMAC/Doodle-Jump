
using System.Collections;
using TMPro;
using UnityEngine;

using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private float moveInput;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private TMP_Text highscoreText;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;

    public float topScore = 0f;
    public float topHighScore = 0f;

    private float LeftX;
    private float RightX;

    private bool m_FacingRight = true;
    private string currentAnimName;

    public static PlayerController instance;

    [SerializeField]
    private GameObject Restart;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        topHighScore = PlayerPrefs.GetFloat("HighScore1", 0);

        highscoreText.text = "High Score: " + topHighScore.ToString();
        scoreText.text = "Score: " + topScore.ToString();

        rb = GetComponent<Rigidbody2D>();

        //LeftX = ((float)Screen.width / (float)Screen.height) * (-5);
        //RightX = ((float)Screen.width / (float)Screen.height) * (5);
        LeftX = (600f / 960f) * (-5);
        RightX = (600f / 960f) * 5;
    }



    private void Update()
    {
        highscoreText.text = "High Score: " + topHighScore.ToString();
        topHighScore = PlayerPrefs.GetFloat("HighScore1", 0);
        moveInput = Input.GetAxis("Horizontal"); // A and D are left, right keys 
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        AddPoint();

        if (moveInput < 0 && m_FacingRight)
        {
            Flip();
        }
        else if (moveInput > 0 && !m_FacingRight)
        {
            Flip();
        }

        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }


        if (transform.position.x > RightX)
        {
            Vector2 XPlayer = transform.position;
            XPlayer.x = LeftX;
            transform.position = XPlayer;
        }
        else if (transform.position.x < LeftX)
        {
            Vector2 XPlayer = transform.position;
            XPlayer.x = RightX;
            transform.position = XPlayer;
        }
        if (PlayAgain.Play)
        {
            Restart.SetActive(true);
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 5 && animator.GetBool("isJump"))
        {
            ChangeAnim("isIdle");
            animator.SetBool("isJump", false);
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 25f)
        {
            Vector2 vector2 = gameObject.GetComponent<Rigidbody2D>().velocity;
            vector2.y = 25f;
            gameObject.GetComponent<Rigidbody2D>().velocity = vector2;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Spring") || collision.gameObject.CompareTag("MovePlatform") && gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            ChangeAnim("isJumping");
            animator.SetBool("isJump", true);
        }
    }

    public void AddPoint()

    {
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        highscoreText.text = "High Score: " + Mathf.Round(topHighScore).ToString();

        if (topHighScore < topScore)
            PlayerPrefs.SetFloat("HighScore1", topScore);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            animator.ResetTrigger(animName);
            currentAnimName = animName;
            animator.SetTrigger(currentAnimName);
        }
    }
}



