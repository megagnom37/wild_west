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
		startShotTime = time;
	}

    public void startProc()
	{
        GameController.GetPlayer(name).ShowReady();
        StartCoroutine (SleepToStart());
	}

	IEnumerator SleepToStart()
	{
		yield return new WaitForSeconds (startShotTime);
        GameController.GetPlayer(name).ShowFire();
        startTime = Time.time;
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
        player.isShotWas = true;
		player.SetResult (time);
	}
}
