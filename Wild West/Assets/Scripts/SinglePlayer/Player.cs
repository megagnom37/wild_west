using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator _animator;
    public GameObject leg;
    public GameObject hand;
    public GameObject gun;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        gun.transform.parent = leg.transform;
    }
	
	public void SetHandAsParent()
    {
        gun.transform.parent = hand.transform;
    }
}
