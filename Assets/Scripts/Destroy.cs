using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Destroy : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject platformPrefab;

    [SerializeField]
    private GameObject springPrefab;

    [SerializeField]
    private GameObject movePlatform;

    [SerializeField]
    private GameObject breakPlatform;

    [SerializeField]
    private float spaceSpamPlatform = 13f;

    [SerializeField]
    private Transform gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Platform");
        Collider2D[] colliders;
        Vector2 spacePlatform;
        float spacePlatformY;
        float spacePlatformX;
        do
        {
            spacePlatformX = Random.Range(-2.6f, 2.6f);
            spacePlatformY = gameOver.transform.position.y + spaceSpamPlatform + (int)Random.Range(0, 2);
            spacePlatform = new Vector2(spacePlatformX, spacePlatformY);

            colliders = Physics2D.OverlapBoxAll(spacePlatform, new Vector2(1.5f, 1f), 0);
        } while (colliders.Length > 0);

        if (collision.gameObject.CompareTag("Platform"))
        {
            
            if (transform.position.y < 190) // Easy
            {
                if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 2)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }
                else
                {
                    collision.gameObject.transform.position = spacePlatform;
                }
            }
            else if (transform.position.y >= 190 && transform.position.y <= 390) // Medium
            {
                if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 2 || Random.Range(1, 9) == 3)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }
                else
                {
                    collision.gameObject.transform.position = spacePlatform;
                }
            }
            else if (transform.position.y > 390) // Hard
            {
                if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 2 || Random.Range(1, 9) == 3 || Random.Range(1, 9) == 4)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }
                else
                {
                    collision.gameObject.transform.position = spacePlatform;
                }
            }


        }
        else if (collision.gameObject.CompareTag("Spring"))
        {
            if (transform.position.y < 190) // Easy
            {
                if (Random.Range(1, 9) == 1)
                {
                    collision.gameObject.transform.position = spacePlatform;

                }
                else if (Random.Range(1, 9) == 2)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }

                else
                {
                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }

            else if (transform.position.y >= 190 && transform.position.y <= 390) // Medium
            {
                if (Random.Range(1, 9) == 1)
                {
                    collision.gameObject.transform.position = spacePlatform;

                }
                else if (Random.Range(1, 9) == 2 || Random.Range(1, 9) == 3)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }
                else
                {
                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }
            else if (transform.position.y > 390) // Hard
            {
                if (Random.Range(1, 9) == 1)
                {
                    collision.gameObject.transform.position = spacePlatform;

                }
                else if (Random.Range(1, 9) == 2 || Random.Range(1, 9) == 3 || Random.Range(1, 9) == 4)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }
                else
                {
                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }


        }
        else if (collision.gameObject.CompareTag("MovePlatform"))
        {

            if (transform.position.y < 190) // Easy
            {
                if (Random.Range(1, 9) == 2)
                {
                    collision.gameObject.transform.position = spacePlatform;

                }
                else if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }
                else
                {
                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }

            else if (transform.position.y >= 190 && transform.position.y <= 390) // Medium
            {
                if (Random.Range(1, 9) == 2 || Random.Range(1, 9) == 3)
                {
                    collision.gameObject.transform.position = spacePlatform;

                }
                else if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }
                else
                {
                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }

            else if (transform.position.y > 390) // Hard
            {
                if (Random.Range(1, 9) == 2 || Random.Range(1, 9) == 3 || Random.Range(1, 9) == 4)
                {
                    collision.gameObject.transform.position = spacePlatform;

                }
                else if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    Destroy(collision.gameObject);
                    Instantiate(breakPlatform, spacePlatform, Quaternion.identity);
                }
                else
                {
                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }



        }
        else if (collision.gameObject.CompareTag("BreakPlatform"))
        {
            if (transform.position.y < 190) // Easy
            {
                if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 2)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    collision.gameObject.transform.position = spacePlatform;
                }
                else
                {
                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }
            else if (transform.position.y >= 190 && transform.position.y <= 390) // Medium
            {
                if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 2 || Random.Range(1, 9) == 3)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    collision.gameObject.transform.position = spacePlatform;
                }
                else
                {

                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }
            else if (transform.position.y > 390) // Hard
            {
                if (Random.Range(1, 9) == 1)
                {
                    Destroy(collision.gameObject);
                    Instantiate(springPrefab, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 2 || Random.Range(1, 9) == 3 || Random.Range(1, 9) == 4)
                {
                    Destroy(collision.gameObject);
                    Instantiate(movePlatform, spacePlatform, Quaternion.identity);
                }
                else if (Random.Range(1, 9) == 5)
                {
                    collision.gameObject.transform.position = spacePlatform;
                }
                else
                {
                    Destroy(collision.gameObject);
                    Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
                }
            }


        }


        //Vector2 spacePlatform = new Vector2(Random.Range(-2.7f, 2.7f), this.transform.position.y + (9.5f + Random.Range(1f, 2f)));

        //if (Random.Range(1, 7) > 1)
        //    myPlat = (GameObject)Instantiate(platformPrefab, spacePlatform, Quaternion.identity);

        //else
        //myPlat = (GameObject)Instantiate(springPrefab, spacePlatform , Quaternion.identity);

        //Destroy(collision.gameObject);
    }
}
