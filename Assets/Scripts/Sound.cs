using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioClip jump;

    [SerializeField]
    private AudioClip spring;

    private AudioSource saw;

    public static Sound instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        saw= GetComponent<AudioSource>();
    }

    public void Jump()
    {
        saw.PlayOneShot(jump);
    }

    public void Spring()
    {
        saw.PlayOneShot(spring);
    }
}
