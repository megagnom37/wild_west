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
    [SerializeField] Color loseColorPanel;
    [SerializeField] Color winColorPanel;

    public void SetResult(string result, float time)
    {
        _resultMatch.text = "YOU " + result;
        if (result == "WIN")
            GetComponent<Image>().color = winColorPanel;
        else
            GetComponent<Image>().color = loseColorPanel;

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
