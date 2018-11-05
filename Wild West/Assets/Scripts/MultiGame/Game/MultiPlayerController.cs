using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MultiPlayerController : NetworkBehaviour
{
 
    [SerializeField] private TextMesh _text;

    private bool flag1= true;
    private bool flag2 = true;
    private MultiCharacterController player1;
    private MultiCharacterController player2;

    private void Update()
    {
        if ((this.GetComponent<NetworkManager>().numPlayers == 2) && flag1)
        {
            flag1 = false;
            player1 = GameObject.Find("HostPlayer").GetComponent<MultiCharacterController>();
            player2 = GameObject.Find("ClientPlayer").GetComponent<MultiCharacterController>();

            player1.CmdMyStartGame();
            player2.CmdMyStartGame();
        }

        if (this.GetComponent<NetworkManager>().numPlayers == 2)
        {
            if (player1._shootIsDone && player2._shootIsDone && flag2)
            {
                flag2 = false;
                if (player1._resultGameTime < player2._resultGameTime)
                {
                    print(player1._resultGameTime);
                    print(player2._resultGameTime);
                    print("WIN PLAYER1");
                    _text.text = "WIN PLAYER1";
                }
                else
                {
                    print(player1._resultGameTime);
                    print(player2._resultGameTime);
                    print("WIN PLAYER2");
                    _text.text = "WIN PLAYER2";
                }
            }
        }
    }

}
