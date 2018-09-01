using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class MenuAudio : MonoBehaviour {

    #region Variable Declarations
    [SerializeField] AudioClip menuConfirmSound;
    [Range(0f, 1f)]
    [SerializeField] float menuConfirmVolume = 1f;

    AudioSource audioSource;
    #endregion



    #region Unity Event Functions
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    #endregion



    #region Public Functions
    public void PlayConfirm()
    {
        audioSource.PlayOneShot(menuConfirmSound, menuConfirmVolume);
    }
	#endregion
}
