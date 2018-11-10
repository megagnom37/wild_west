using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	[SerializeField] private ShopController shopCtrl;

	[SerializeField] private GameObject characterSpawn;
	private GameObject characterCurrent;

	[SerializeField] private Button buttonBuy; 
	[SerializeField] private Text textBalance; 

	void Start()
	{
		textBalance.text = shopCtrl.GetMoneyBalance ().ToString() + "$";
		SetCurrentCharacter( shopCtrl.GetCurrentCharacter () );
	}

	public void OnMainMenuClick()
	{
		shopCtrl.SaveSelectedCharacter ();
		SceneManager.LoadScene("main_menu");
	}

	public void OnBuyClick()
	{
		if (shopCtrl.BuyCharacter ()) {
			SetCurrentCharacter (shopCtrl.GetCurrentCharacter ());
			textBalance.text = shopCtrl.GetMoneyBalance ().ToString() + "$";
		}
	}

	public void OnLeftClick()
	{
		SetCurrentCharacter( shopCtrl.GetNextCharacter () );
	}

	public void OnRightClick()
	{
		SetCurrentCharacter( shopCtrl.GetPrevoiusCharacter () );
	}
		
	private void SetCurrentCharacter(GameObject character)
	{
		if (characterCurrent != null)
			Destroy (characterCurrent);
		characterCurrent = Instantiate (character, characterSpawn.transform);

		buttonBuy.interactable = !shopCtrl.IsCurrentBought ();
	}
}
