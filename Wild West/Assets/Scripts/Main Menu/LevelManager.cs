using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public GameObject pref;

    public void OnSinglePlayerClick()
    {
        SceneManager.LoadScene("single_player_menu");
    }

    public void OnMultiPlayerClick()
    {
        SceneManager.LoadScene("multi_player_menu");
    }

    public void OnSettingsClick()
    {
        SceneManager.LoadScene("settings");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

	public void OnShopClick()
	{
		SceneManager.LoadScene("shop");
	}

    public void Start()
    {
        Instantiate(pref);
    }
}
