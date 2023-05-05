using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            gameObject.SetActive(false);
        }
    }
}
