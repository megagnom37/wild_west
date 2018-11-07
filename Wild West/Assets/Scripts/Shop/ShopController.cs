using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {

	[SerializeField] private List<GameObject> characters = new List<GameObject> ();
	[SerializeField] private GameObject lockedCharacter;
	[SerializeField] private int characterCost = 20;

	private int currentIndex = 0;
	private int money = 0;

	void Awake()
	{
		money = PlayerPrefs.GetInt ("money", 0);
		currentIndex = PlayerPrefs.GetInt ("currentCharacter", 0);
	}

	public void SaveSelectedCharacter()
	{
		if (IsCurrentBought())
			PlayerPrefs.SetInt ("currentCharacter", currentIndex);
	}

	public bool BuyCharacter()
	{
		if (money > characterCost) {
			money -= characterCost;
			PlayerPrefs.SetInt (characters [currentIndex].name + "_b", 1);
			PlayerPrefs.SetInt ("money", money);
			return true;
		}
		else
			return false;

	}

	public GameObject GetCurrentCharacter()
	{
		if (IsCurrentBought())
			return characters [currentIndex];
		else
			return lockedCharacter;
	}

	public GameObject GetNextCharacter()
	{
		currentIndex = (currentIndex + 1) % characters.Count;
		return GetCurrentCharacter ();
	}

	public GameObject GetPrevoiusCharacter()
	{
		currentIndex--;
		if (currentIndex < 0)
			currentIndex = characters.Count - 1;
		return GetCurrentCharacter ();
	}

	public bool IsCurrentBought()
	{
		int isBought = PlayerPrefs.GetInt (characters [currentIndex].name + "_b", 0);
		return (isBought != 0);
	}

	public int GetMoneyBalance()
	{
		return money;
	}
}
