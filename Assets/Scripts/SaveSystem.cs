using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveSystem
{
    private static string SaveKey = "Level_";
    private static string MaxLevelUnlockedKey = "MaxLevel_";
    private static string SarsCount = "StarsCount_";
    private static string MusicState = "MusicState_";
    private static string SFXState = "SFXState_";
    private static string Volume = "Volume_";

    public void Save(int collectedStarsCount)
    {
        int levelCount = SceneManager.GetActiveScene().buildIndex;

        Save(levelCount, collectedStarsCount);
    }

    public void Save(int levelCount, int collectedStarsCount)
    {
        string saveKey = GetSaveKey(levelCount);

        if (!LevelSaveExist(saveKey))
        {
            SaveLevel(saveKey, collectedStarsCount, levelCount);
            return;
        }
;
        int oldCollectedStarsCount = ES3.Load<int>(saveKey);;

        if (!NeedOverride(collectedStarsCount, oldCollectedStarsCount))
            return;

        SaveLevel(saveKey, collectedStarsCount, levelCount, oldCollectedStarsCount);
    }

    public int GetSaveStarsCount(int levelNumber)
    {
        string saveKey = GetSaveKey(levelNumber);

        return ES3.Load(saveKey, 0);

    }

    public bool LevelSaveExist(int levelNumber)
    {
        string saveKey = GetSaveKey(levelNumber);

        return ES3.KeyExists(saveKey);
    }

    public int GetMaxUnlockedLevel()
    {
        return ES3.Load(MaxLevelUnlockedKey, 1);
    }

    public int GetMaxStarsCount()
    {
        return ES3.Load(SarsCount, 0);
    }

    public void SaveMusicState(bool state)
    {
        ES3.Save(MusicState, state);
    }

    public bool LoadMusicState()
    {
        return ES3.Load(MusicState, true);
    }

    public void SaveSFXState(bool state)
    {
        ES3.Save(SFXState, state);
    }

    public bool LoadSFXState()
    {
        return ES3.Load(SFXState, true);
    }

    public void SaveVolume(float volume)
    {
        ES3.Save(Volume, volume);
    }

    public float LoadVolume()
    {
        return ES3.Load(Volume, 1f);
    }

    private void SetMaxUnlockedLevel(int level)
    {
        int newMaxLevel = level + 1;

        Debug.LogError(level);
        Debug.LogError(newMaxLevel);

        ES3.Save(MaxLevelUnlockedKey, newMaxLevel);
    }

    private void SaveLevel(string saveKey, int collectedStarsCount, int levelCount)
    {
        SaveLevel(saveKey, collectedStarsCount, levelCount, 0);
    }

    private void SaveLevel(string saveKey, int collectedStarsCount, int levelCount, int oldCollectedStarsCount)
    {
        ES3.Save(saveKey, collectedStarsCount);

        if (levelCount >= GetMaxUnlockedLevel())
            SetMaxUnlockedLevel(levelCount);

        int starsCountDif = collectedStarsCount - oldCollectedStarsCount;
        int savedStars = GetMaxStarsCount();
        int newStarsCount = savedStars + starsCountDif;

        SaveMaxStarsCount(newStarsCount);
    }

    private void SaveMaxStarsCount(int newCount)
    {
        ES3.Save(SarsCount, newCount);
    }

    private bool NeedOverride(int currentStarsCount, int lastStarsCount)
    {
        return currentStarsCount > lastStarsCount;
    }

    private bool LevelSaveExist(string saveKey)
    {
        return ES3.KeyExists(saveKey);
    }

    private string GetSaveKey(int levelNumber)
    {
        return SaveKey + levelNumber.ToString();
    }
}
