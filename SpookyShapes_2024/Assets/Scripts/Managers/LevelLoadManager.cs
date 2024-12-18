using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadManager : SingletonBase<LevelLoadManager>
{
    public static string[] LevelNamesList =
    {
        "MainMenu",
        "MainGame",
        "OptionsMenu",
        "AddSpell",
    };

    #region SerializeFields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Loading screen script to call methods on")]
    private LoadingScreen loadingScreen;

    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("Bool to tell if a level is loading")]
    private bool isLoadingLevel = false;

    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("The name of the level currently loaded and in use")]
    private List<string> currentLevelList;
    #endregion

    #region Getters&Setters
    public bool IsLoadingLevel { get { return isLoadingLevel; } }
    #endregion

    // Load a new level method
    public void StartLoadNewLevel(string levelName, bool showLoadingScreen)
    {
        StartCoroutine(LoadLevel(levelName, showLoadingScreen));
    }

    // Load a new level but as a menu additive
    public void LoadMenuOverlay(string menuName)
    {
        SceneManager.LoadScene(menuName, LoadSceneMode.Additive);
        currentLevelList.Insert(0, menuName); // Insert at front
    }

    // Unload a menu
    public void UnloadMenuOverlay(string menuName)
    {
        SceneManager.UnloadSceneAsync(menuName);
        currentLevelList.RemoveAt(currentLevelList.IndexOf(menuName)); // Remove first
    }

    // Coroutine to load level properly
    private IEnumerator LoadLevel(string sceneToLoad, bool showLoadingScreen)
    {
        isLoadingLevel = true;
        Time.timeScale = 1;

        if (showLoadingScreen)
            loadingScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        // Unload all opened scenes (Not the persistent scene
        if (currentLevelList.Count != 0)
        {
            for (int i = 0; i < currentLevelList.Count; i++)
                SceneManager.UnloadSceneAsync(currentLevelList[i]);
            currentLevelList.Clear();
        }

        // Load new scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            loadingScreen.UpdateSlider(asyncLoad.progress);
            yield return null;
        }
        loadingScreen.UpdateSlider(1);

        currentLevelList.Add(sceneToLoad);

        // Initialize player etc.
        yield return new WaitForSeconds(0.5f);

        loadingScreen.gameObject.SetActive(false);
        isLoadingLevel = false;

        yield break;
    }

    public void DisableLoadingScreeen()
    {
        loadingScreen.gameObject.SetActive(false);
    }
}
