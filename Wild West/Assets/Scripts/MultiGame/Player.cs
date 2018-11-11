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
    [SyncVar] public bool isShotWas = false;

    public GameObject modelObject;
	public bool isPlayer = false;

	private GameObject resultPanel;
    private Text _infoText;

    void Start()
	{
        if (isLocalPlayer)
        {
            isPlayer = true;

            modelObject = GameObject.Find("CharacterPlayer");

            _infoText = GameObject.Find("t_info").GetComponent<Text>();
            if (isServer)
                _infoText.text = "WAIT OPPONENT";
            else
                _infoText.text = "READY";

            resultPanel = GameObject.Find("p_result");
            resultPanel.SetActive(false);
        }
        else
        {
            modelObject = GameObject.Find("Enemy");
        }
	}

    private void Update()
    {
        if (isShotWas)
        {
            modelObject.GetComponent<PlayerAnimator>().Shoot();
            isShotWas = false;
        }
    }

    public void ShowReady()
    {
        if (isPlayer)
            _infoText.text = "READY";
    }

    public void ShowFire()
    {
        if (isPlayer)
            _infoText.text = "FIRE";
    }

	public void ShowResults()
	{
        if (resultMatch == "LOSE")
            modelObject.GetComponent<PlayerAnimator>().Dead();
        if (isResultReady && isPlayer)
        {
            resultPanel.GetComponent<ResultPanelController>().SetResult(resultMatch, resultTime);
            resultPanel.SetActive(true);
        }
	}

	public void SetResult(float time)
	{
        resultTime = time;
		GameController.SetPlayerTime (name, resultTime);
	}

    public void ShotAnime()
    {
        print("ShotAnime");
    }

}
