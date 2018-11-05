using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiCharacterController : NetworkBehaviour {

    private float _startGameTime = 0.0f;
    private float _endGameTime = 0.0f;
    public float _resultGameTime = 0.0f;
    public bool _shootIsDone = false;

    void Start () {
        this.gameObject.transform.position = new Vector3(6, 1.5f, -1);
        if (this.isLocalPlayer)
        {
            this.gameObject.transform.position = new Vector3(-6, 1.5f, -1);
            this.name = "HostPlayer";
        }
        else
        {
            this.name = "ClientPlayer";
        }
    }

    [Command(channel = 0)] // Server
    public void CmdMyStartGame()
    {
            RpcStartGame();
    }

    [ClientRpc(channel = 0)] // Client
    void RpcStartGame()
    {
        if (this.isLocalPlayer)
        {
            ClickToStart();
        }
    }

    [Command(channel = 0)] // Server
    void CmdSetResultTime(float res)
    {
            _resultGameTime = res;
    }

    public void ClickToStart()
    {
        if (isClient)
        {
            float timeForStartGame = 5.0f; // + Random.Range(-2.0f, 2.0f)
            print("Time to start: " + timeForStartGame.ToString());
            ClickManager.OnClicked += this.ClickToShot;
            StartCoroutine(StartGameAfterSeconds(timeForStartGame));
        }
    }

    IEnumerator StartGameAfterSeconds(float timeInSec)
    {
        print("Ready");
        GameObject.Find("Txt").GetComponent<TextMesh>().text = "Ready";
        yield return new WaitForSeconds(timeInSec);
        _startGameTime = Time.time;
        print("Go");
        GameObject.Find("Txt").GetComponent<TextMesh>().text = "Go";

    }

    public void ClickToShot()
    {
        _endGameTime = Time.time;
        ClickManager.OnClicked -= this.ClickToShot;
        _resultGameTime = _endGameTime - _startGameTime;
        CmdSetResultTime(_resultGameTime);
        print("CharacterShootTime: " + _resultGameTime.ToString());
        _shootIsDone = true;
        CmdShootIsDone();
    }

    [Command(channel = 0)]
    void CmdShootIsDone()
    {
        _shootIsDone = true;
    }

}
