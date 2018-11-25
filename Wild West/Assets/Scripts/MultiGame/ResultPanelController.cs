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
        if (result == "WIN")
            _resultMatch.text = LanguageManager.Translate("t_win");
        else if (result == "LOSE")
            _resultMatch.text = LanguageManager.Translate("t_lose");
        else if (result == "TIE")
            _resultMatch.text = LanguageManager.Translate("t_tie");

        if (result == "WIN")
            GetComponent<Image>().color = winColorPanel;
        else
            GetComponent<Image>().color = loseColorPanel;

        if (time < 0f)
            _resultTime.text = LanguageManager.Translate("t_failed");
        else
            _resultTime.text = LanguageManager.Translate("t_time") + time.ToString("0.000");
    }

    public void OnMainMenuClick()
    {
        NetworkManager.Shutdown();
        Destroy(GameObject.Find("NetworkManager"));
        Destroy(GameObject.Find("NetworkDiscovery"));

        SceneManager.LoadScene("main_menu");
    }
}
