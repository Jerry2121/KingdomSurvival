using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject PatchNotesPanel;
    public GameObject ExitConfirmCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitConfirmCanvas.SetActive(false);
        }
    }
    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {

    }
    public void Settings()
    {

    }
    public void Credits()
    {

    }
    public void PatchNotesToggle()
    {
        PatchNotesPanel.SetActive(!PatchNotesPanel.activeSelf);
        GetComponent<AudioSource>().Play();
    }
    public void ExitApplication()
    {
        ExitConfirmCanvas.SetActive(!ExitConfirmCanvas.activeSelf);
        GetComponent<AudioSource>().Play();
    }
    public void ExitConfirmYes()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }
    public void ExitConfirmNo()
    {
        ExitConfirmCanvas.SetActive(!ExitConfirmCanvas.activeSelf);
        GetComponent<AudioSource>().Play();
    }
}
