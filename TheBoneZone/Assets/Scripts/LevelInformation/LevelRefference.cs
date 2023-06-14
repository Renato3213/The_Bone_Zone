using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Reference", menuName = "LevelInformation/LevelInformation")]
public class LevelRefference : ScriptableObject
{
    public string CurrentLevel;
    public bool isConquered;
}
