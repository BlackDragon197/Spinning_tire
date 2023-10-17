using System;

[Serializable]
public class Level
{
    public string LevelID;
    public string LevelName;
    public bool isOpened;
    public bool Completed;
    public int Stars;

    public Level(string levelID, string levelName, bool isOpened, bool completed, int stars)
    {
        LevelID = levelID;
        LevelName = levelName;
        this.isOpened = isOpened;
        Completed = completed;
        Stars = stars;
    }
}
