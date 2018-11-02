using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBotManager : MonoBehaviour {
    public EnemyBotProperties[] _botProperties;

    private EnemyBotProperties _currentBotProperties;
    private int _currentID = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void nextID()
    {
        _currentID = (_currentID + 1) % _botProperties.Length;
    }

    public void previousID()
    {
        _currentID--;
        if (_currentID < 0)
        {
            _currentID = _botProperties.Length - 1;
        }
    }

	public EnemyBotProperties CurrentEnemyBotProperties
    {
		get { return _botProperties [_currentID]; }
    }
}
