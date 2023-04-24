using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BackGroundStart;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject GroupPlatform;
    [SerializeField]
    private GameObject SettingSound;
    [SerializeField]
    private GameObject Restart;


    private void Start()
    {
        if(PlayAgain.Play)
        {
            BackGroundStart.SetActive(false);
            SettingSound.SetActive(false);
            Player.SetActive(true);
            GroupPlatform.SetActive(true);

        }
        else
        {
            BackGroundStart.SetActive(true);
            SettingSound.SetActive(true);
            Player.SetActive(false);
            GroupPlatform.SetActive(false);
        }
    }
    public void startGame()
    {
        BackGroundStart.SetActive(false);
        SettingSound.SetActive(false);
        Player.SetActive(true);
        GroupPlatform.SetActive(true);
        Restart.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
        PlayAgain.Play = true;
    }


}
