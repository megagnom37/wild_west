using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ResultPanelController : MonoBehaviour
{
    [SerializeField] Text _resultMatch;
    [SerializeField] Text _resultTime;

    public void SetResult(string result, float time)
    {
        _resultMatch.text = "YOU " + result;

        if (time < 0f)
            _resultTime.text = "FAILED";
        else
            _resultTime.text = "TIME: " + time.ToString("0.000");
    }

    public void OnMainMenuClick()
    {
        NetworkManager.Shutdown();
        Destroy(GameObject.Find("NetworkManager"));
        Destroy(GameObject.Find("NetworkDiscovery"));

        SceneManager.LoadScene("main_menu");
    }
}
