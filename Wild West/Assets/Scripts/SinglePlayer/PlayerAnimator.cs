using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    Animator animator;
    public GameObject leg;
    public GameObject hand;
    public GameObject gun;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        gun.transform.parent = leg.transform;
    }
	
	public void SetHandAsParent()
    {
        gun.transform.parent = hand.transform;
        gun.transform.localPosition = new Vector3(0.106f, 0.028f, -0.0323f);
        gun.transform.localEulerAngles = new Vector3(187.524f, 274.212f, -283.617f);
    }

    public void Shoot()
    {
        animator.SetTrigger("shoot");
    }

    public void Dead()
    {
        animator.SetTrigger("dead");
    }

}
