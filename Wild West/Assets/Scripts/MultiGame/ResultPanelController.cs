using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanelController : MonoBehaviour
{
    [SerializeField] Text _resultMatch;
    [SerializeField] Text _resultTime;

    public void SetResult(string result, float time)
    {
        _resultMatch.text = "You " + result + "!";
        _resultTime.text = "Time: " + time.ToString();
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("main_menu");
    }
}
