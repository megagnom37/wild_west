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
            isPlayer = true;

            resultText = GameObject.Find("Text").GetComponent<Text>();
            if (isServer)
                resultText.text = "Wait opponent!";
            else
                resultText.text = "Ready...";

            resultPanel = GameObject.Find ("Panel");
			//resultPanel.SetActive (false);
		}
	}

    public void ShowReady()
    {
        if (isPlayer)
            resultText.text = "Ready...";
    }

    public void ShowFire()
    {
        if (isPlayer)
            resultText.text = "FIRE!!!";
    }

	public void ShowResults()
	{
		if (isResultReady && isPlayer) {
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
