using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerPrepare : NetworkBehaviour {
	public override void OnStartClient(){
		base.OnStartClient ();

		string id = (2 - ((GetComponent<NetworkIdentity> ().netId.Value) % 2)).ToString ();
        print(id);
		GameController.AddPlayer (id, this.gameObject);
        //print ("OnStartClient: " + NetworkServer.connections.Count);

        if (isServer)
        {
            print("GameController.players.Count: " + GameController.players.Count);
            GetComponent<Shoot>().SetStartShotTime(GameController.GetStartTime());
            if (NetworkServer.connections.Count == 2)
            {
                foreach (GameObject obj in GameController.players.Values)
                    obj.GetComponent<Shoot>().startProc();
                GameObject.Find("b_disconnect").SetActive(false);
            }
        }
        else
        {
            GetComponent<Shoot>().startProc();
            GameObject.Find("b_disconnect").SetActive(false);
        }
    }
}
