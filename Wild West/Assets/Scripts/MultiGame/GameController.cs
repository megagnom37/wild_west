using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

	static private float playerTime = -9999f;
	static private float enemyTime = -9999f;
	static private float timeToStart = 0.0f;

	void Start()
	{
		timeToStart = Random.Range (10, 10);
		print (timeToStart);
	}

	public static void AddPlayer(string id, GameObject player)
	{
		players.Add ("Player " + id, player);
		player.transform.name = "Player " + id;
	}

	public static Player GetPlayer(string id)
	{
		return players [id].GetComponent<Player>();
	}


	public static float GetStartTime()
	{
		return timeToStart;
	}

	static public void SetPlayerTime(string name, float time)
	{
		Player player = players[name].GetComponent<Player> ();
		if (player.isPlayer)
			playerTime = time;
		else
			enemyTime = time;
	}

    static public void ProcResults() {
        Player p1 = players["Player 1"].GetComponent<Player>();
        Player p2 = players["Player 2"].GetComponent<Player>();

        if (playerTime < 0 && enemyTime < 0)
        {
            p1.resultMatch = "tie";
            p2.resultMatch = "tie";
        }
        else if ((playerTime < 0) || ((playerTime > enemyTime) && (enemyTime > 0)))
        {
            p1.resultMatch = "Lose";
            p2.resultMatch = "Win";
        }
        else
        {
            p1.resultMatch = "Win";
            p2.resultMatch = "Lose";
        }

		p1.isResultReady = true;
		p2.isResultReady = true;
	}
}
