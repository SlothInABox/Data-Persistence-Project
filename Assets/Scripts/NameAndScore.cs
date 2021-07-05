using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NameAndScore
{
    public string Name { get; set; }
    public int Score { get; set; }

    // Constructor
    public NameAndScore(string name, int score)
    {
        this.Name = name;
        this.Score = score;
    }
}
