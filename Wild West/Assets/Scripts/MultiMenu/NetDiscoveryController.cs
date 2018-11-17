using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetDiscoveryController : NetworkDiscovery {

	private string ipAddress = null;

	public override void OnReceivedBroadcast (string fromAddress, string data)
	{
        print(fromAddress);
		ipAddress = fromAddress;
	}
	
	public string GetServerIpAddress()
	{
		return ipAddress;
	}
}
