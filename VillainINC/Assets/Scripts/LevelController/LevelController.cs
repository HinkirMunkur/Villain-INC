using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : SingletonnPersistent<LevelController>
{
    [SerializeField] private int firstLevelIndex;

    private const string CURR_LEVEL_INDEX = "CURR_LEVEL_INDEX";

    public int GetCurrentSavedLevelIndex()
    {
        return PlayerPrefs.GetInt(CURR_LEVEL_INDEX, 2);
    }

    public void SetCurrentSavedLevelIndex(int levelIndex)
    {
        if (levelIndex >= GetTotalAmountOfLevel())
        {
            levelIndex = firstLevelIndex;
        }
        
        PlayerPrefs.SetInt(CURR_LEVEL_INDEX, levelIndex);
    }
    
    public void LoadLevelWithIndex(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCurrLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSceneWithName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public int GetTotalAmountOfLevel()
    {
        return SceneManager.sceneCountInBuildSettings;
    }

    public string GetSceneNameWithIndex(int index)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(index);
        return path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);
    }

    public Scene GetCurrentScene()
    {
        return SceneManager.GetActiveScene();
    }
    public string GetScenePathWithIndex(int index)
    {
        return SceneUtility.GetScenePathByBuildIndex(index);
    }

    public int GetCurrentLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    
#if  UNITY_EDITOR
    public void SetCurrentSceneDirty()
    {
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(GetCurrentScene());
    }
#endif

}
