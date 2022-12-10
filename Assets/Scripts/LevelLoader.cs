using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelLoader : MonoBehaviour
{
    private static float LoadDelay = 0.2f;

    private UIManager uIManager;
    private bool isLoading;

    [Inject]
    private void Constructor(UIManager uIManager)
    {
        this.uIManager = uIManager;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        LoadScene(currentSceneIndex);
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentSceneIndex);
    }

    public void LoadScene(int index)
    {
        if (isLoading)
        {
            Debug.LogError("Already loading");
            return;
        }

        if(index < 0)
        {
            Debug.LogError("Incorrect load index. < 0");
            return;
        }    

        int sceneCount = SceneManager.sceneCountInBuildSettings;

        if (index >= sceneCount)
        {
            Debug.LogError("Too hight index, loading main scene.");
            Debug.LogError("Index | scene count: " + index + " | " + sceneCount);
            StartCoroutine(LoadCoroutine(0));
            return;
        }

        StartCoroutine(LoadCoroutine(index));
    }

    private IEnumerator LoadCoroutine(int sceneIndex)
    {
        isLoading = true;

        uIManager.SetActiveUI(false);

        yield return new WaitForSeconds(LoadDelay);

        SceneManager.LoadScene(sceneIndex);

        isLoading = false;
    }
}
