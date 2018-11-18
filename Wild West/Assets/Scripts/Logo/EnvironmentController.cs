using UnityEngine;

public class EnvironmentController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

}
