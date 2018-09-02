using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NGlow
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] GameEvent resumeEvent;
        public bool OptionsMenuActive { get; set; }
        bool gameIsPaused;
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;

        public bool GameIsPaused { get { return gameIsPaused; } }

        // Use this for initialization

        private void Update()
        {
            if (gameIsPaused && !OptionsMenuActive && Input.GetButtonDown(Constants.INPUT_CANCEL))
            {
                resumeEvent.Raise();
            }
        }

        public void ShowCursor()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;;
        }

        public void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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