using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private void Start()
    {
        if(animator.GetBool("Run") == true)
        {
            animator.SetBool("Run", false);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            
            if(!animator.GetBool("Run"))
            AudioManager.instance.PlaySFX("Break");
            animator.SetBool("Run", true);
        }
    }
}
