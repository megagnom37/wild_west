using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MultiPlayerController : NetworkBehaviour
{
    // print(this.GetComponent<NetworkManager>().numPlayers);
    [SerializeField] private TextMesh _text;

    private bool flag1= true;
    private bool flag2 = true;
   // private MultiCharacterController player1;
    //private MultiCharacterController player2;



    private void Update()
    {
        // ВЫПОЛНЯЕТСЯ ТОЛЬКО НА СЕРВЕРЕ ПО ДЕФОЛТУ
       if ((this.GetComponent<NetworkManager>().numPlayers == 2) && flag1)
        {
            flag1 = false;
            //player1 = GameObject.Find("LocalPlayer").GetComponent<MultiCharacterController>();
            //player2 = GameObject.Find("NotLocalPlayer").GetComponent<MultiCharacterController>();
            GameObject.Find("HostPlayer").GetComponent<MultiCharacterController>().CmdMyStartGame();
            //print("Hello22222");
            GameObject.Find("ClientPlayer").GetComponent<MultiCharacterController>().CmdMyStartGame();

            //player1.name = "CHANGE";
            //player2.name = "CHANGE";
        }
       // ОТРЕФАКТОРИТЬ (код чтобы просто работало)
       if (this.GetComponent<NetworkManager>().numPlayers == 2)
       if (GameObject.Find("HostPlayer").GetComponent<MultiCharacterController>()._shootIsDone &&
            GameObject.Find("ClientPlayer").GetComponent<MultiCharacterController>()._shootIsDone && flag2)
        {
            flag2 = false;
            if (GameObject.Find("HostPlayer").GetComponent<MultiCharacterController>()._resultGameTime < 
                GameObject.Find("ClientPlayer").GetComponent<MultiCharacterController>()._resultGameTime)
            {
                    print(GameObject.Find("HostPlayer").GetComponent<MultiCharacterController>()._resultGameTime);
                    print(GameObject.Find("ClientPlayer").GetComponent<MultiCharacterController>()._resultGameTime);
                    print("WIN PLAYER1");
                _text.text = "WIN PLAYER1";
            }
            else
            {
                    print(GameObject.Find("HostPlayer").GetComponent<MultiCharacterController>()._resultGameTime);
                    print(GameObject.Find("ClientPlayer").GetComponent<MultiCharacterController>()._resultGameTime);
                    print("WIN PLAYER2");
                _text.text = "WIN PLAYER2";
            }
        }
    }
    /*
    IEnumerator LoadScene()
    {
        print("StartLoadScene");
        yield return new WaitForSeconds(2);
        print("Tap to start");
        ClickManager.OnClicked += clickToStart;
    }
    
    private float _startGameTime = 0.0f;
    [SerializeField] private GameObject _resultPanel;

    // Use this for initialization
    void Start () {
        StartCoroutine(LoadScene());
    }


    void clickToStart()
    {
        float timeForStartGame = 5.0f + Random.Range(-2.0f, 2.0f);
        print("Time to start: " + timeForStartGame.ToString());
        ClickManager.OnClicked -= clickToStart;
        ClickManager.OnClicked += _player.ClickToShot;
        StartCoroutine(StartGameAfterSeconds(timeForStartGame));
    }

    IEnumerator StartGameAfterSeconds(float timeInSec)
    {
        print("Ready");
        yield return new WaitForSeconds(timeInSec);
        _startGameTime = Time.time;
        print("Go");

        StartCoroutine(ResultGameAfterSeconds(3.0f));
    }

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
