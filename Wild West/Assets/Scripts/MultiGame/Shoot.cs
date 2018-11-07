using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shoot : NetworkBehaviour {

	[SyncVar] private float startShotTime = 0.0f;
	private float startTime = 0.0f;
	private float tapToShot = 0.0f;
	private bool isShotWas = false;

	public void SetStartShotTime(float time)
	{
		if (isServer) {
			startShotTime = time;
			print ("SetStartShotTime.isServer");
		}
	}

    public void Start()
    {
        if (isLocalPlayer)
        {
            Player player = GameController.GetPlayer(transform.name);
            player.isPlayer = true;
        }
            
    }

    public void startProc()
	{
		StartCoroutine (SleepToStart());
	}

	IEnumerator SleepToStart()
	{
		print ("startShotTime: " + startShotTime.ToString ());
		yield return new WaitForSeconds (startShotTime);
		startTime = Time.time;
		print ("startTime: " + startTime.ToString ());
		StartCoroutine (Sleep5Sec());
	}

	IEnumerator Sleep5Sec()
	{
		if (isServer)
			yield return new WaitForSeconds (4);
		else 
			yield return new WaitForSeconds (5);
		if (isServer)
			GameController.ProcResults ();

		Player player = GameController.GetPlayer (name);
		player.ShowResults ();
	}
		
	void Update () 
	{
		if (!isLocalPlayer)
			return;

		if (Input.GetKeyDown(KeyCode.Space) && !isShotWas) {
			isShotWas = true;
			Click ();
		}
	}

	[Client]
	void Click()
	{
		tapToShot = Time.time;
		print ("tapToShot: " + tapToShot.ToString ());
		if (startTime != 0.0f)
			CmdWasShoot (transform.name, tapToShot - startTime);
		else
			CmdWasShoot (transform.name, -1);
	}

	[Command]
	void CmdWasShoot(string name, float time)
	{
		Player player = GameController.GetPlayer (name);
		player.SetResult (time);
		Debug.Log (name + " : " + (time).ToString());
	}
}
