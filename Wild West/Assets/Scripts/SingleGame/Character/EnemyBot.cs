using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot : MonoBehaviour {
    private EnemyBotProperties _botProperties;
    private float shotTime;

    public void setProperties(EnemyBotProperties properties)
    {
        _botProperties = properties;
    }

    public float getShootTime()
    {
        return shotTime;
    }

    public void Shoot()
    {
        shotTime = _botProperties.averageTime + Random.Range(-0.05f, 0.05f);
        StartCoroutine(WaitBeforeShoot());
    }

    public void Dead()
    {
        GetComponent<PlayerAnimator>().Dead();
    }

    IEnumerator WaitBeforeShoot()
    {
        yield return new WaitForSeconds(shotTime);
        GetComponent<PlayerAnimator>().Shoot();
    }
}