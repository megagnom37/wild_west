﻿using System.Collections;
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
                _infoText.text = LanguageManager.Translate("t_wait");
            else
                _infoText.text = LanguageManager.Translate("t_ready");

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
            _infoText.text = LanguageManager.Translate("t_ready");
    }

    public void ShowFire()
    {
        if (isPlayer)
        {
            _infoText.color = new Color(1f, 0.17f, 0.17f, 1);
            _infoText.text = LanguageManager.Translate("t_fire");
        }    
    }

	public void ShowResults()
	{
        if (resultMatch == "LOSE")
            modelObject.GetComponent<PlayerAnimator>().Dead();
        if (isResultReady && isPlayer)
        {
            resultPanel.GetComponent<ResultPanelController>().SetResult(resultMatch, resultTime);
            _infoText.enabled = false;
            resultPanel.SetActive(true);
        }
	}

	public void SetResult(float time)
	{
        resultTime = time;
		GameController.SetPlayerTime (name, resultTime);
	}
}
