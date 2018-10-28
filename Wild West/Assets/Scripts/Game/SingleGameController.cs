using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGameController : MonoBehaviour {
    [SerializeField] private CharacterObject player;
    private EnemyBot enemy;
    private EnemyBotManager _enemyBotManager;
    GameObject enemyObj;
    private float _startGameTime = 0.0f;

    void Start () {
        //TODO: Tap for start the game
        _enemyBotManager = GameObject.Find("EnemyBotManager").GetComponent<EnemyBotManager>();
        enemyObj = Instantiate(_enemyBotManager.getCurrentEnemyBotProperties().botModel, new Vector3(6, 1, 1), transform.rotation) as GameObject;
        enemyObj.transform.localScale = new Vector3(1, 1, 1);
        enemyObj.AddComponent<EnemyBot>();
        enemy = enemyObj.GetComponent<EnemyBot>();
        enemy.setProperties(_enemyBotManager.getCurrentEnemyBotProperties());

        float timeForStartGame = 5.0f + Random.Range(-2.0f, 2.0f);
        print(timeForStartGame);
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
        float resultTime = player.ShootTime - _startGameTime;
        print(resultTime);
        print(enemy.getShootTime());
        if ((resultTime > 0.0f) && (player.ShootTime > 0.0f) && (resultTime < enemy.getShootTime()))
        {
            print("Win!");
            enemy.gameObject.transform.Rotate(new Vector3(90, 0, 0));
        }
        else
        {
            print("Lose!");
            player.gameObject.transform.Rotate(new Vector3(90, 0, 0));
        }
    }
}