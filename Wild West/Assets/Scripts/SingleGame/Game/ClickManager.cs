using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {
    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    private float _clickTime = 0.0f;
		
    private void Update()
    {
		if (Input.GetMouseButtonDown(0) && (OnClicked != null))
        {
            _clickTime = Time.time;
            OnClicked();
            print("OnClick: " + _clickTime.ToString());
        }
    }

	public float ClickTime
	{
		get { return _clickTime; }
	}
}