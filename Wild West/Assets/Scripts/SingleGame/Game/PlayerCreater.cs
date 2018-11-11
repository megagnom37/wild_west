using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreater : MonoBehaviour {
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private List<GameObject> characters = new List<GameObject>();
    private GameObject currentCharacter;

    private void Awake()
    {
        int currentCharacterIdx = PlayerPrefs.GetInt("currentCharacter", 0);
        currentCharacter = Instantiate(characters[currentCharacterIdx], playerSpawn.transform);
        currentCharacter.name = "CharacterPlayer";
    }

    public GameObject GetCurrentPlayer()
    {
        return currentCharacter;
    }
}
