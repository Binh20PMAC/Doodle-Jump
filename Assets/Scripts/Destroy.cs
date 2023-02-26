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
    private float spaceSpamPlatform = 3f;

    private GameObject myPlat;


    // Start is called before the first frame update
 

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Collider2D collider;
        Vector2 spacePlatform;
        float spacePlatformY;
        float spacePlatformX;
        int maxTry = 10;
        int count = 0;

        do
        {
             spacePlatformX = Random.Range(-2.6f, 2.6f);
             spacePlatformY = player.transform.position.y + spaceSpamPlatform + (int)Random.Range(0, 2);
             spacePlatform = new Vector2(spacePlatformX, spacePlatformY);

             collider = Physics2D.OverlapBox(spacePlatform,new Vector2(2.5f,2.5f),0);
            count++;

        } while (collider != null && count  < maxTry);


        if (collision.CompareTag("Platform"))
        {
            if (Random.Range(1, 8) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(springPrefab, spacePlatform, Quaternion.identity);
            }
            else if (Random.Range(1, 8) == 2)
            {
                Destroy(collision.gameObject);
                Instantiate(movePlatform, spacePlatform, Quaternion.identity);
            }
            else
            {
                collision.gameObject.transform.position = spacePlatform;
            }
        }
        else if (collision.CompareTag("Spring"))
        {
            if (Random.Range(1, 8) == 1)
            {
                collision.gameObject.transform.position = spacePlatform;

            }
            else if (Random.Range(1, 8) == 2)
            {
                Destroy(collision.gameObject);
                Instantiate(movePlatform, spacePlatform, Quaternion.identity);
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
            }
        }
        else if (collision.CompareTag("MovePlatform"))
        {
            if (Random.Range(1, 8) == 2)
            {
                collision.gameObject.transform.position = spacePlatform;

            }
            else if (Random.Range(1, 8) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(springPrefab, spacePlatform, Quaternion.identity);
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, spacePlatform, Quaternion.identity);
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
