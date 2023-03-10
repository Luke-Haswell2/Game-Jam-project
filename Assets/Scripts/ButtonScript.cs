using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject[] menu;

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionsButton()
    {
        menu[0].SetActive(false);
        menu[1].SetActive(true);
    }
    public void InstructionsButton()
    {
        menu[0].SetActive(false);
        menu[2].SetActive(true);
    }
    public void OptionsBackButton()
    {
        menu[1].SetActive(false);
        menu[0].SetActive(true);
    }
    public void InstructionsBack()
    {
        menu[2].SetActive(false);
        menu[0].SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
