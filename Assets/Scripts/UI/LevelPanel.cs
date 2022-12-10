using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelPanel : UIPanel
{
    [SerializeField] private int levelCount;
    [SerializeField] private LevelGridElement levelGridElementPrefab;
    [SerializeField] private RectTransform gridParent;

    private List<LevelGridElement> levelGridElements = new List<LevelGridElement>();
    private SaveSystem saveSystem;

    [Inject]
    private void Constructor(SaveSystem saveSystem)
    {
        this.saveSystem = saveSystem;
    }

    private void Start()
    {
        PrepareGrid();
        LoadLevelsData();
    }

    private void PrepareGrid()
    {
        LevelGridElement newElement;

        for (int i = 0; i < levelCount; i++)
        {
            newElement = Instantiate(levelGridElementPrefab, gridParent);
            levelGridElements.Add(newElement);
            newElement.SetInteractable(false);
            newElement.SetLevelCount(i + 1);
        }
    }

    private void LoadLevelsData()
    {
        int maxLevel = saveSystem.GetMaxUnlockedLevel();

        if (maxLevel > levelCount)
            Debug.LogError("Incorrect max saved level | level count: " + maxLevel + " | " + levelCount);

        for (int i = 0; i < maxLevel; i++)
        {
            var gridElement = levelGridElements[i];
            int levelNumber = i + 1;
            int starCount = saveSystem.GetSaveStarsCount(levelNumber);

            gridElement.SetInteractable(true);

            gridElement.SetStarCount(starCount);
        }
    }


}


