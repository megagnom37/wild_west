﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanelManager : MonoBehaviour {
	[SerializeField] Text _resultMatch;
	[SerializeField] Text _resultTime;
    [SerializeField] Color loseColorPanel;
    [SerializeField] Color winColorPanel;

    void Awake()
	{
		gameObject.SetActive (false);
	}

	public void SetResult(int result, float time)
	{
        if (result == 1)
        {
            _resultMatch.text = LanguageManager.Translate("t_win");
            GetComponent<Image>().color = winColorPanel;
        }
        else
        {
            _resultMatch.text = LanguageManager.Translate("t_lose");
            GetComponent<Image>().color = loseColorPanel;
        }

        if (time < 0f)
            _resultTime.text = LanguageManager.Translate("t_failed");
        else
            _resultTime.text = LanguageManager.Translate("t_time") + time.ToString("0.000");
    }

	public void OnMainMenuClick()
	{
		Destroy (GameObject.Find ("EnemyBotManager"));
		SceneManager.LoadScene("main_menu");
	}

	public void OnRestartClick()
	{
		SceneManager.LoadScene("single_player_game");
	}
}
