using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGameManager : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
