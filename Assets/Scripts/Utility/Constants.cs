using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helper class containing all strings and constants used in the game
/// </summary>
public class Constants 
{
    #region Inputs
    public static readonly string INPUT_HORIZONTAL = "Horizontal";
    public static readonly string INPUT_VERTICAL = "Vertical";
    public static readonly string INPUT_INTERACT = "Interact";
    public static readonly string INPUT_SHIELD = "Fire1";
    public static readonly string INPUT_SLOWMO = "Fire2";
    public static readonly string INPUT_MOUSE_X = "Mouse X";
    public static readonly string INPUT_MOUSE_Y = "Mouse Y";
    public static readonly string INPUT_JUMP = "Jump";
    public static readonly string INPUT_CRAWL = "Crawl";
    public static readonly string INPUT_SUBMIT = "Submit";
    public static readonly string INPUT_CANCEL = "Cancel";
    public static readonly string INPUT_ESCAPE = "Escape";
    public static readonly string INPUT_DEBUGMODE = "DebugMode";
    #endregion

    #region Tags and Layers
    public static readonly string TAG_PLAYER = "Player";
    public static readonly string TAG_LASER = "Laser";
    public static readonly string TAG_ENEMY = "Enemy";
    public static readonly string TAG_SHIELD = "Shield";
    #endregion

    #region Scenes
    public static readonly string SCENE_LOGIC = "Main_Logic";
    public static readonly string SCENE_ENVIRONMENT = "Main_Environment";
    public static readonly string SCENE_GUI = "Main_GUI";
    public static readonly string SCENE_MENU = "MainMenu";
    #endregion

    #region Sounds
    // Exposed Parameters in Mixers
    public static readonly string MIXER_SFX_VOLUME = "SFXVolume";
    public static readonly string MIXER_MUSIC_VOLUME = "MusicVolume";
    #endregion
    
}