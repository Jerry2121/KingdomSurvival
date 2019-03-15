using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject PatchNotesPanel;
    public GameObject ExitConfirmCanvas;
    public GameObject MainButtonsGameObject;
    [Header("Continue Screen GameObjects")]
    public GameObject SelectedSavedGameInfoTab;
    public GameObject ContinueCanvas;
    public GameObject NotSelectingSavedGameWhenLoading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && MainButtonsGameObject.activeSelf == true)
        {
            ExitConfirmCanvas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && MainButtonsGameObject.activeSelf == false && ContinueCanvas.activeSelf == true)
        {
            MainButtonsGameObject.SetActive(!MainButtonsGameObject.activeSelf);
            ContinueCanvas.SetActive(!ContinueCanvas.activeSelf);
            SelectedSavedGameInfoTab.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && ContinueCanvas.activeSelf == true && SelectedSavedGameInfoTab.activeSelf == true || Input.GetKeyDown(KeyCode.Mouse1) && ContinueCanvas.activeSelf == true && NotSelectingSavedGameWhenLoading.activeSelf == true)
        {
            GetComponent<AudioSource>().Play();
            SelectedSavedGameInfoTab.SetActive(false);
            NotSelectingSavedGameWhenLoading.SetActive(false);
        }
    }
    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {
        GetComponent<AudioSource>().Play();
        MainButtonsGameObject.SetActive(!MainButtonsGameObject.activeSelf);
        ContinueCanvas.SetActive(!ContinueCanvas.activeSelf);
        PatchNotesPanel.SetActive(false);
        SelectedSavedGameInfoTab.SetActive(false);
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
    public void LoadSavedGame()
    {
        if (SelectedSavedGameInfoTab.activeSelf == true)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
        else
        {
            NotSelectingSavedGameWhenLoading.SetActive(true);
        }
    }
    public void SelectSave()
    {
        GetComponent<AudioSource>().Play();
        NotSelectingSavedGameWhenLoading.SetActive(false);
        SelectedSavedGameInfoTab.SetActive(true);
    }
    public void DeleteSave()
    {
        GetComponent<AudioSource>().Play();
        SelectedSavedGameInfoTab.SetActive(false);
    }
}
