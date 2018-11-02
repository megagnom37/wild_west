using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanelManager : MonoBehaviour {
//	[SerializeField] GameObject _resultPanel;
	[SerializeField] Text _resultMatch;
	[SerializeField] Text _resultTime;

	void Awake()
	{
		gameObject.SetActive (false);
	}

	public void SetResult(string result, float time)
	{
		_resultMatch.text = "You " + result + "!";
		_resultTime.text = "Time: " + time.ToString();
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
