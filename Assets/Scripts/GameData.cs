using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Settings/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public int LevelCompleted;
    public int WeaponSelected;
    public int TotalScores;
    public int Coins;
    public int Gems;
    public string PlayerName;
    public bool SetPlayerName;
    public bool RemoveAds;
}