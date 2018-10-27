using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : MonoBehaviour {
    private float _characterShootTime = 0.0f;

    [SerializeField] private ClickManager _clickManager;

    void GetClickTime()
    {
        _characterShootTime = _clickManager.ClickTime;
    }

    void Start()
    {
        ClickManager.OnClicked += GetClickTime;
    }

    public float ShootTime
    {
        get { return _characterShootTime; }
    }
}