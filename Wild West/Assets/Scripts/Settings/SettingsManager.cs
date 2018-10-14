using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("main_menu");
    }
}
