using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    bool isPaused;
    public KeyCode pauseButton;
    public bool go;

    public GameObject panelPause;
    public GameObject player;
    FirstPersonController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            isPaused = !isPaused;
        }
        if (go == true)
        {
            if (isPaused)
            {
                Time.timeScale = 0;
                panelPause.SetActive(true);
                controller.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                panelPause.SetActive(false);
                controller.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.DeleteKey("Eat");
        PlayerPrefs.DeleteKey("Hp");
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Prodol()
    {
        isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
