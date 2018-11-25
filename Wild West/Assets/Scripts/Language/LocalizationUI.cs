using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationUI : MonoBehaviour {
    private void Awake()
    {
        GetComponent<Text>().text = LanguageManager.Translate(gameObject.name);
    }
}
