using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// 
/// </summary>
public class OptionsMenu : MonoBehaviour {

    #region Variable Declarations
    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] Toggle InvertXToggle;
    [SerializeField] Toggle InvertYToggle;
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] Button backButton;
    [SerializeField] AudioMixer masterMixer;
    Resolution[] resolutions;
    #endregion



    #region Unity Event Functions
    private void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height) 
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;
        //InvertXToggle.isOn = NGlow.Input.invertX;
        //InvertYToggle.isOn = NGlow.Input.invertY;
        //sensitivitySlider.value = NGlow.Input.mouseSens;
	}
	
	private void Update() {
        if (Input.GetButtonDown(Constants.INPUT_CANCEL)) {
            backButton.onClick.Invoke();
        }
	}
    #endregion



    #region Public Functions
    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetMusicVolume(float volume)
    {
        masterMixer.SetFloat(Constants.MIXER_MUSIC_VOLUME, volume);
    }

    public void SetSFXVolume(float volume)
    {
        masterMixer.SetFloat(Constants.MIXER_SFX_VOLUME, volume);
    }

    public void SetSensitivity(float sensitivity)
    {
        //NGlow.Input.mouseSens = sensitivity;
    }

    public void InvertY(bool invertY)
    {
        //NGlow.Input.invertY = invertY;
    }

    public void InvertX(bool invertX)
    {
        //NGlow.Input.invertX = invertX;
    }
    #endregion



    #region Private Functions
    #endregion
}
