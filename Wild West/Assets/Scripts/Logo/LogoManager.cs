using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Loading());
        AudioListener.volume = PlayerPrefs.GetInt("sound", 0);
    }
	
	IEnumerator Loading()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("main_menu");
    }
}
