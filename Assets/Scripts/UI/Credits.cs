using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public static Credits Instance;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
