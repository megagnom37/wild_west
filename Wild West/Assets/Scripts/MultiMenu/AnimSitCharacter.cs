using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSitCharacter : MonoBehaviour {

    Animation animat;
    public float delayBetweenAnimation = 3f;

    // Use this for initialization
    void Start()
    {
        animat = GetComponent<Animation>();
        StartCoroutine(SitPlay());
    }

    IEnumerator SitPlay()
    {
        animat.Play();
        yield return new WaitForSeconds(delayBetweenAnimation);
        StartCoroutine(SitPlay());
    }
}
