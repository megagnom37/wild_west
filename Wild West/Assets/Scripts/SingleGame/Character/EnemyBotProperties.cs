using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct EnemyBotProperties
{
    public GameObject botModel;
    public float averageTime;
    public string name;
    public string description;
    public int headCost;
}