using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    public GameObject virtualCursor;
    [Space]
    public static bool gameIsPaused;

    public AudioSource audioSource;
    [Space]
    public GameObject pauseMenu;
    public GameObject Buttons; //buttons of the Main Menu
    [Space]
    public GameObject OptionsWindow;
    [Space]
    public Toggle fullscreenToggle;
    public Slider musicSlider;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }

    private void Start()
    {
        gameIsPaused = false;
    }


    public void PauseGame()
    {
        //if (!GameOver.Instance.isGameOver && !WinSystem.Instance.isGameWin)
        //{
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();

                //if (GamepadCursor.Instance.playerInput.currentControlScheme != "Gamepad")
                //{
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                //}
            }
        //}
    }

    void Paused()
    {
        pauseMenu.SetActive(true);
        Buttons.SetActive(true);
        OptionsWindow.SetActive(false);

        virtualCursor.SetActive(true);

        Time.timeScale = 0;

        gameIsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Buttons.SetActive(false);

        virtualCursor.SetActive(false);

        Time.timeScale = 1;

        gameIsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadMainMenu()
    {
        Resume();

        SaveSystem.instance.Save(SceneManager.GetActiveScene().buildIndex); //saving the current scene, not the next one
        SaveSystem.instance.SaveOptions(); //save options when closing the options menu

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        SceneManager.LoadScene("Menu");
    }

    /// Options Window
	public void Options() //from menu to options
    {
        SaveSystem.instance.LoadOptions(); //load options when entering options menu

        fullscreenToggle.isOn = SaveSystem.instance.isFulscreen;
        Screen.fullScreen = SaveSystem.instance.isFulscreen;

        musicSlider.value = SaveSystem.instance.music;
        GetComponent<AudioSource>().volume = SaveSystem.instance.music;

        Buttons.SetActive(false); //to make sure you can't click them while in the options menu
        OptionsWindow.SetActive(true); //options menu
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
    }

    public void VolumeSlider()
    {
        GetComponent<AudioSource>().volume = musicSlider.value;
    }

    public void SensitivitySlider()
    {
        //you have to make a virtual mouse cursor to change the sensitivity
    }

    public void OptionsBack() //from options back to the main menu
    {
        SaveSystem.instance.SaveOptions(); //save options when closing the options menu

        OptionsWindow.SetActive(false);
        Buttons.SetActive(true);
    }

    public void ResetOptionsDefault()
    {
        fullscreenToggle.isOn = true;
        Screen.fullScreen = true;

        musicSlider.value = musicSlider.maxValue;
    }
}