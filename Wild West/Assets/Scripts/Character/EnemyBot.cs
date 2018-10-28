using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot : MonoBehaviour {
    //[SerializeField] private float _averageShootTime = 0.3f;
    private EnemyBotProperties _botProperties;

    public void setProperties(EnemyBotProperties properties)
    {
        _botProperties = properties;
    }

    public float getShootTime()
    {
        return _botProperties.averageTime + Random.Range(-0.05f, 0.05f);
       // return _averageShootTime + Random.Range(-0.05f, 0.05f);
    }
}