using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGameController : MonoBehaviour {
    [SerializeField] private CharacterObject _player;

	private EnemyBotManager _enemyBotManager;
	[SerializeField] private GameObject _enemySpawn;
    private EnemyBot _enemy;

	[SerializeField] private GameObject _resultPanel;

    private float _startGameTime = 0.0f;

    void Start () {
		_enemyBotManager = GameObject.Find("EnemyBotManager").GetComponent<EnemyBotManager>();
		StartCoroutine(LoadScene());
		InitEnemy ();
    }

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(2);
		print ("Tap to start");
		ClickManager.OnClicked += clickToStart;
	}

	void InitEnemy()
	{
		GameObject enemyObj;
		enemyObj = Instantiate(_enemyBotManager.CurrentEnemyBotProperties.botModel, 
							   _enemySpawn.transform.position, 
							   _enemySpawn.transform.rotation) as GameObject;
		enemyObj.transform.localScale = new Vector3(1, 1, 1);
		_enemy = enemyObj.AddComponent<EnemyBot>();
		_enemy.setProperties(_enemyBotManager.CurrentEnemyBotProperties);
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
		_resultPanel.SetActive (true);
        if ((resultTime > 0.0f) && (resultTime < _enemy.getShootTime()))
        {
            print("Win!");
			_resultPanel.GetComponent<ResultPanelManager> ().SetResult ("WIN", resultTime);
            _enemy.gameObject.transform.Rotate(new Vector3(90, 0, 0));
        }
        else
        {
            print("Lose!");
			_resultPanel.GetComponent<ResultPanelManager> ().SetResult ("LOSE", resultTime);
            _player.gameObject.transform.Rotate(new Vector3(90, 0, 0));
        }
    }
}