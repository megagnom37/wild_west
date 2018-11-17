using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBotManager : MonoBehaviour {
    [SerializeField] private EnemyBotManager _enemyBotManager;

    [SerializeField] private GameObject _botSpawn;
    [SerializeField] private Text _textName;
    [SerializeField] private Text _textDescription;
    [SerializeField] private Text _textTime;
    [SerializeField] private Text _textReward;

    private GameObject currentBotObject;

    private void Start()
    {
        UpdateEnemyBotProperties();
    }

    public void OnNextButtonDown()
    {
        _enemyBotManager.nextID();
        UpdateEnemyBotProperties();
    }

    public void OnPreviousButtonDown()
    {
        _enemyBotManager.previousID();
        UpdateEnemyBotProperties();
    }

    private void UpdateEnemyBotProperties()
    {
        EnemyBotProperties currentEnemyBot = _enemyBotManager.CurrentEnemyBotProperties;

        if (currentBotObject)
            Destroy(currentBotObject);

        currentBotObject = Instantiate(currentEnemyBot.botModel, _botSpawn.transform) as GameObject;
        //currentBotObject.transform.localPosition = new Vector3(0, 0, 0);

        _textName.text = currentEnemyBot.name;
        _textDescription.text = currentEnemyBot.description;
        _textTime.text = "Avrg Shoot Time: " + currentEnemyBot.averageTime.ToString();
        _textReward.text = "Reward: " + currentEnemyBot.headCost.ToString() + "$";
    }
}
