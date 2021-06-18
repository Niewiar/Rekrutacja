using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData",menuName ="Create new game data")]
public class GameData : ScriptableObject
{
    public int collectedCoins;
    public int playerLife;
}
