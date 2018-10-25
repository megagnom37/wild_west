using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutVersionManager : MonoBehaviour {
    Text version;

    void Awake(){
        version = GetComponent<Text>();
        version.text = Application.version;
    }
}
