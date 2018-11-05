using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiCharacterController : NetworkBehaviour {

    private float _startGameTime = 0.0f;
    private float _endGameTime = 0.0f;
    public float _resultGameTime = 0.0f;
    public bool _shootIsDone = false;
    // private ClickManager _clickManager;

    // Use this for initialization
    void Start () {
       // _clickManager = new ClickManager();
        this.gameObject.transform.position = new Vector3(6, 1.5f, -1);
        if (isLocalPlayer)
        {
            this.gameObject.transform.position = new Vector3(-6, 1.5f, -1);
            this.name = "HostPlayer";
        }
        else
        {
            this.name = "ClientPlayer";
        }

    }

    [Command(channel = 0)]
    public void CmdMyStartGame()
    {
        //StartCoroutine(LoadScene());
        if (isServer)
            RpcStartGame();
    }

    // Так как серверы также являются клиентами!!!
    [ClientRpc(channel = 0)]
    void RpcStartGame()
    {
        if (this.isClient && this.isLocalPlayer) //(this.isClient)
        {
            StartCoroutine(LoadScene());
        }
    }

    [Command(channel = 0)]
    void CmdSetResultTime(float res)
    {
        if (isServer)
            _resultGameTime = res;
    }

    IEnumerator LoadScene()
    {
        print("StartLoadScene");
        yield return new WaitForSeconds(0);
        print("Tap to start"); //??????????
        GameObject.Find("Txt").GetComponent<TextMesh>().text = "Tap to start";
        ClickManager.OnClicked += clickToStart;
    }

    void clickToStart()
    {
        float timeForStartGame = 5.0f; // + Random.Range(-2.0f, 2.0f)
        print("Time to start: " + timeForStartGame.ToString());
        ClickManager.OnClicked -= clickToStart;
        ClickManager.OnClicked += this.ClickToShot;
        StartCoroutine(StartGameAfterSeconds(timeForStartGame));
    }

    IEnumerator StartGameAfterSeconds(float timeInSec)
    {
        print("Ready");
        GameObject.Find("Txt").GetComponent<TextMesh>().text = "Ready";
        yield return new WaitForSeconds(timeInSec);
        _startGameTime = Time.time;
        print("Go");
        GameObject.Find("Txt").GetComponent<TextMesh>().text = "Go";

        //StartCoroutine(ResultGameAfterSeconds(3.0f));
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


    /*
    IEnumerator ResultGameAfterSeconds(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);

        float resultTime = _player.ShootTime - _startGameTime;
        print(resultTime);
        print(_enemy.getShootTime());
        _resultPanel.SetActive(true);
        if ((resultTime > 0.0f) && (resultTime < _enemy.getShootTime()))
        {
            print("Win!");
            _resultPanel.GetComponent<ResultPanelManager>().SetResult("WIN", resultTime);
            _enemy.gameObject.transform.Rotate(new Vector3(90, 0, 0));
        }
        else
        {
            print("Lose!");
            _resultPanel.GetComponent<ResultPanelManager>().SetResult("LOSE", resultTime);
            _player.gameObject.transform.Rotate(new Vector3(90, 0, 0));
        }
    }
    */
}
