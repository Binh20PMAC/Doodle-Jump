using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameManager : MonoBehaviour
{
   
     bool Pause = true;

    [SerializeField]
    private GameObject Background;

    [SerializeField]
    private GameObject PauseBackround;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Pause = !Pause;
           Background.SetActive(false);
           PauseBackround.SetActive(true);

            if(Pause == true)
            {
                Background.SetActive(true);
                PauseBackround.SetActive(false);
            }
        }
       

        Time.timeScale = (Pause) ? 1.00f : 0.00f; //If your time scale isn't working, change Paused to !Paused
  
    }
}
