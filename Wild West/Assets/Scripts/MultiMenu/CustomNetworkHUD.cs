using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkHUD : MonoBehaviour {
    private bool started = false;
    [SerializeField] private int port; 

    public void OnHostClick()
    {
        if (!started)
        {
            started = true;
            NetworkManager.singleton.networkPort = port;
            NetworkManager.singleton.StartHost();
        }
    }

    public void OnClientClick()
    {
        if (!started)
        {
            started = true;
            NetworkManager.singleton.networkAddress = "localhost";
            NetworkManager.singleton.networkPort = port;
            NetworkManager.singleton.StartClient();
        }
    }
}
