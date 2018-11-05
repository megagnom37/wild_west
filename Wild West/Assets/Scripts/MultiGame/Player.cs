using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour 
{
	[SyncVar] private float resultTime = 0.0f;
	[SyncVar] public bool isResultReady = false;
	[SyncVar] public string resultMatch;
	public bool isPlayer = false;

	private GameObject resultPanel;
	private Text resultText;

	void Start()
	{
		if (isLocalPlayer) {
			resultPanel = GameObject.Find ("Panel");
			resultText = GameObject.Find ("Text").GetComponent<Text>();
			resultPanel.SetActive (false);
		}
	}

	public void ShowResults()
	{
		if (isResultReady && isPlayer) {
			transform.name = "Winner: " + resultTime.ToString();
			resultText.text = resultMatch;
			resultPanel.SetActive (true);
		}
	}

	public void SetResult(float time)
	{
		resultTime = time;
		GameController.SetPlayerTime (name, resultTime);
	}
}
