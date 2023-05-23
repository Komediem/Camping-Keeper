using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }

    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SaveSystem.instance.Save(currentScene);

        SceneManager.LoadScene(currentScene + 1);
    }
}
