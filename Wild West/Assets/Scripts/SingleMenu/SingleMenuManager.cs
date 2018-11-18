using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleMenuManager : MonoBehaviour {

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("main_menu");
        Destroy(GameObject.Find("EnemyBotManager"));
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("single_player_game");
    }
}
