﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : MonoBehaviour {
    private float _characterShootTime = 0.0f;

    public ClickManager _clickManager;

    public void ClickToShot()
    {
		_characterShootTime = _clickManager.ClickTime;
		ClickManager.OnClicked -= this.ClickToShot;
        GetComponent<PlayerAnimator>().Shoot();
		print("CharacterShootTime: " + _characterShootTime.ToString());
    }

    public void Dead()
    {
        GetComponent<PlayerAnimator>().Dead();
    }

    public float ShootTime
    {
        get { return _characterShootTime; }
    }
}