using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public GameObject campfirePref;

    [Header("Sound")]
    public Sprite soundIconOn;
    public Sprite soundIconOff;
    public Image soundIcon;
    public Text soundText;

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("main_menu");
        PlayerPrefs.SetInt("sound", (int)AudioListener.volume);
    }

    public void OnSoundClick()
    {
        if ((int)AudioListener.volume != 0)
        {
            soundIcon.sprite = soundIconOff;
            soundText.text = "SOUND OFF";
            AudioListener.volume = 0f;
        }
        else
        {
            soundIcon.sprite = soundIconOn;
            soundText.text = "SOUND ON";
            AudioListener.volume = 1f;
        }
    }

    public void Start()
    {
        Instantiate(campfirePref);
        if ((int)AudioListener.volume != 0)
        {
            soundIcon.sprite = soundIconOn;
            soundText.text = "SOUND ON";
        }
        else
        {
            soundIcon.sprite = soundIconOff;
            soundText.text = "SOUND OFF";
        }
    }
}
