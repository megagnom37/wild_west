using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class CustomNetworkHUD : MonoBehaviour {
    private bool started = false;
    [SerializeField] private int port;
	[SerializeField] private NetDiscoveryController netDiscovery;


    public void OnHostClick()
    {
        if (!started)
        {
            started = true;
			netDiscovery.Initialize ();
			netDiscovery.StartAsServer ();
            NetworkManager.singleton.networkPort = port;
            NetworkManager.singleton.StartHost();
        }
    }

    public void OnClientClick()
    {
        if (!started)
        {
			netDiscovery.Initialize ();
			netDiscovery.StartAsClient ();

            started = true;

			StartCoroutine (StartClient ());
        }
    }

	IEnumerator StartClient()
	{
        yield return new WaitForSeconds(0.5f);
        string serverIp = netDiscovery.GetServerIpAddress ();
		print (serverIp);
        if (serverIp == null)
			StartCoroutine (StartClient ());
		else {
			Regex ipTemplate = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
			MatchCollection result = ipTemplate.Matches(serverIp);
			serverIp = result[0].ToString(); 
			print (serverIp);

			NetworkManager.singleton.networkAddress = serverIp;
			NetworkManager.singleton.networkPort = port;
			NetworkManager.singleton.StartClient();
        }
	}
}
