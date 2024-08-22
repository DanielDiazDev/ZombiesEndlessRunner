using System;
using System.Collections.Generic;

[Serializable]
public class ScoreEntry 
{
    public string Name;
    public float Score;

    public ScoreEntry(string name, float score)
    {
        Name = name;
        Score = score;
    }
}

[Serializable]
public class ScoreList
{
    public List<ScoreEntry> list;
}
