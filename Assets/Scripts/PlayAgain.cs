using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public static bool Play = false;
    public void playAgain()
    {
        SceneManager.LoadScene("SampleScene");
        Play = true;
    }
    public void menu()
    {
        SceneManager.LoadScene("SampleScene");
        Play = false;
    }

}
