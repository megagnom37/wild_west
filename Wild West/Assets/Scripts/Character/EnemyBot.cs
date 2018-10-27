using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot : MonoBehaviour {
    [SerializeField] private float _averageShootTime = 0.3f;

    public float getShootTime()
    {
        return _averageShootTime + Random.Range(-0.05f, 0.05f);
    }
}