using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBotManager : MonoBehaviour {
    [SerializeField] private EnemyBotManager _enemyBotManager;

    [SerializeField] private GameObject _botSpawn;
    [SerializeField] private Text _textDescription;
    [SerializeField] private Text _textProperties;

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

        currentBotObject = Instantiate(currentEnemyBot.botModel, new Vector3(0, 0, 0), transform.rotation) as GameObject;

        currentBotObject.transform.SetParent(_botSpawn.transform);
        currentBotObject.transform.localPosition = new Vector3(0, 0, 0);

        _textDescription.text = currentEnemyBot.description.text;
        _textProperties.text = "Average time: " + currentEnemyBot.averageTime.ToString();
    }
}
