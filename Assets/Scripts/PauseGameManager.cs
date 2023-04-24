using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameManager : MonoBehaviour
{
    private bool Pause = true;

    [SerializeField]
    private GameObject PauseBackround;

    public void pause()
    {
        Pause = !Pause;
        PauseBackround.SetActive(!Pause);
        Time.timeScale = (Pause) ? 1.00f : 0.00f; //If your time scale isn't working, change Paused to !Paused
    }
}
