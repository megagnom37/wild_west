using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerPrepare : NetworkBehaviour {
	public override void OnStartClient(){
		base.OnStartClient ();

		string id = GetComponent<NetworkIdentity> ().netId.ToString ();
		GameController.AddPlayer (id, this.gameObject);
		print ("OnStartClient: " + NetworkServer.connections.Count);

		if (isServer) {
			GetComponent<Shoot> ().SetStartShotTime (GameController.GetStartTime ());
			if (NetworkServer.connections.Count == 2) {
				foreach (GameObject obj in GameController.players.Values)
					obj.GetComponent<Shoot> ().startProc ();
			}
		} else
			GetComponent<Shoot> ().startProc ();
	}
}
