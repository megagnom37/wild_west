using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleGameController : MonoBehaviour {
    private CharacterObject _player;
    [SerializeField] private PlayerCreater playerCreater;
    [SerializeField] private ClickManager _clickManager;

    private EnemyBotManager _enemyBotManager;
	[SerializeField] private GameObject _enemySpawn;
    private EnemyBot _enemy;

	[SerializeField] private GameObject _resultPanel;
    [SerializeField] private Text _infoText;

    private float _startGameTime = 0.0f;

    void Start () {
        _enemyBotManager = GameObject.Find("EnemyBotManager").GetComponent<EnemyBotManager>();
        InitPlayer();
        InitEnemy();
        clickToStart();
    }

    void InitPlayer()
    {
        GameObject obj = playerCreater.GetCurrentPlayer();
        _player = obj.AddComponent<CharacterObject>();
        _player._clickManager = _clickManager;
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
		float timeForStartGame = 4.0f + Random.Range(-1.5f, 1.5f);
		ClickManager.OnClicked += _player.ClickToShot;
		StartCoroutine(StartGameAfterSeconds(timeForStartGame));
	}

    IEnumerator StartGameAfterSeconds(float timeInSec)
    {
        _infoText.text = "READY";
        yield return new WaitForSeconds(timeInSec);
        _startGameTime = Time.time;
        _infoText.text = "FIREEEE";
        _enemy.Shoot();

        StartCoroutine(ResultGameAfterSeconds(2f));
    }

    IEnumerator ResultGameAfterSeconds(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);

        _infoText.enabled = false;

        float resultTime = _player.ShootTime - _startGameTime;
        print(resultTime);
        print(_enemy.getShootTime());
		_resultPanel.SetActive (true);
        if ((resultTime > 0.0f) && (resultTime < _enemy.getShootTime()))
        {
            _enemy.Dead();
			_resultPanel.GetComponent<ResultPanelManager> ().SetResult ("WIN", resultTime);
        }
        else
        {
            _player.Dead();
			_resultPanel.GetComponent<ResultPanelManager> ().SetResult ("LOSE", resultTime);
        }
    }
}