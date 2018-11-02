using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot : MonoBehaviour {
    private EnemyBotProperties _botProperties;

    public void setProperties(EnemyBotProperties properties)
    {
        _botProperties = properties;
    }

    public float getShootTime()
    {
        return _botProperties.averageTime + Random.Range(-0.05f, 0.05f);
    }
}