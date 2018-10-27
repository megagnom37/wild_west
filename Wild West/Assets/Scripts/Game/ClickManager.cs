using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {
    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    private float _clickTime = 0.0f;

    public float ClickTime
    {
        get { return _clickTime; }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickTime = Time.time;
            OnClicked();
            print("OnClick" + _clickTime.ToString());
        }
    }
}