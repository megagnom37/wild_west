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
