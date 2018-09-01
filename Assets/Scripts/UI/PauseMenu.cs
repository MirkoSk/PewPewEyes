using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NGlow
{
    public class PauseMenu : MonoBehaviour
    {

        GameObject pauseMenu,
                      mainMenu,
                      optionsMenu;
        GameObject resumeButton;
        EventSystem eventSystem;
        bool gameIsPaused;
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;

        public bool GameIsPaused { get { return gameIsPaused; } }

        // Use this for initialization
        void Start()
        {
            pauseMenu = transform.parent.Find("PauseMenu").gameObject;
            mainMenu = pauseMenu.transform.Find("MainMenu").gameObject;
            resumeButton = mainMenu.transform.Find("ResumeButton").gameObject;
            optionsMenu = pauseMenu.transform.Find("OptionsMenu").gameObject;
            eventSystem = GameObject.FindObjectOfType<EventSystem>();
            fpsController = GameManager.Instance.Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        }

        private void Update()
        {
            if (gameIsPaused && !optionsMenu.gameObject.activeSelf && Input.GetButtonDown(Constants.INPUT_CANCEL))
            {
                resumeButton.GetComponent<Button>().onClick.Invoke();
            }

            if (Input.GetButtonDown(Constants.INPUT_ESCAPE))
            {
                if (gameIsPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void PauseGame()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
            fpsController.enabled = false;
            pauseMenu.SetActive(true);
            mainMenu.SetActive(true);
            eventSystem.SetSelectedGameObject(resumeButton);
            gameIsPaused = true;
        }

        public void ResumeGame()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            fpsController.enabled = true;
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            eventSystem.SetSelectedGameObject(null);
            gameIsPaused = false;
        }

        public void ReturnToMainMenu()
        {
            // Put the code to execute from UI here
        }

        public void ExitGame()
        {
            Debug.Log("Exiting the game");
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}