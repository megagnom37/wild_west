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
    public Text languageText;

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
            soundText.text = LanguageManager.Translate("t_sound_off");
            AudioListener.volume = 0f;
        }
        else
        {
            soundIcon.sprite = soundIconOn;
            soundText.text = LanguageManager.Translate("t_sound_on");
            AudioListener.volume = 100f;
        }
    }

    public void OnLanguageClick()
    {
        if (PlayerPrefs.GetInt("language", 0) == 0)
        {
            PlayerPrefs.SetInt("language", 1);
            languageText.text = "РУССКИЙ";
        }
        else
        {
            PlayerPrefs.SetInt("language", 0);
            languageText.text = "ENGLISH";
        }
        SceneManager.LoadScene("settings");
    }

    public void Start()
    {
        Instantiate(campfirePref);

        AudioListener.volume = PlayerPrefs.GetInt("sound", 0);
        if ((int)AudioListener.volume != 0)
        {
            soundIcon.sprite = soundIconOn;
            soundText.text = LanguageManager.Translate("t_sound_on");
        }
        else
        {
            soundIcon.sprite = soundIconOff;
            soundText.text = LanguageManager.Translate("t_sound_off"); 
        }
        languageText.text = LanguageManager.Translate("t_language");
    }
}
