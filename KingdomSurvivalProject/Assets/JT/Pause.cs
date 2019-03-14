using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject HudGameObject;
    [SerializeField]
    private GameObject PauseMenuObject;
    [SerializeField]
    private GameObject PauseMenuConfirm;
    public bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            HudGameObject.GetComponent<Canvas>().enabled = false;
            PauseMenuObject.GetComponent<Canvas>().enabled = true;
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PauseMenuObject.GetComponent<Canvas>().enabled = false;
            PauseMenuConfirm.GetComponent<Canvas>().enabled = false;
            HudGameObject.GetComponent<Canvas>().enabled = true;
            paused = false;
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuObject.GetComponent<Canvas>().enabled = false;
        PauseMenuConfirm.GetComponent<Canvas>().enabled = false;
        HudGameObject.GetComponent<Canvas>().enabled = true;
        paused = false;
    }
    public void ExitToMainMenu()
    {
        HudGameObject.GetComponent<Canvas>().enabled = false;
        PauseMenuObject.GetComponent<Canvas>().enabled = false;
        PauseMenuConfirm.GetComponent<Canvas>().enabled = true;
    }
    public void PauseConfirmYes()
    {
        PauseMenuObject.GetComponent<Canvas>().enabled = false;
        PauseMenuConfirm.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene(0);
    }
    public void PauseConfirmNo()
    {
        PauseMenuConfirm.GetComponent<Canvas>().enabled = false;
        PauseMenuObject.GetComponent<Canvas>().enabled = true;
    }
}
