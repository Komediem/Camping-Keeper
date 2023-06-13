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
    public GameObject Buttons; //buttons of the Pause Menu

    [Space]
    public GameObject OptionsWindow;
    public GameObject OptionsButtons; //buttons of the options
    [Space]
    public Toggle fullscreenToggle;
    public Slider musicSlider;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        //assign some variables to murder errors
        virtualCursor = GameObject.Find("VirtualCursor");
        if (virtualCursor == null)
        {
            virtualCursor = GameObject.Find("VirtualMouse");
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        gameIsPaused = false;

        OptionsWindow.SetActive(false);
        OptionsButtons.SetActive(false);

        Buttons.SetActive(false);

        pauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(Buttons.transform.GetChild(0).gameObject);

            Paused();
        }
    }

    void Paused()
    {
        pauseMenu.SetActive(true);
        Buttons.SetActive(true);
        OptionsWindow.SetActive(false);

        //EventSystem.current.SetSelectedGameObject(Buttons.transform.GetChild(0).gameObject);

        //virtualCursor.SetActive(true);

        PlayerController.Instance.lockMovements = true;

        gameIsPaused = true;

        Cursor.visible = true;
        
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Buttons.SetActive(false);

        PlayerController.Instance.lockMovements = false;

        gameIsPaused = false;

        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        //virtualCursor.SetActive(false);

        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        Resume();

        //SaveSystem.instance.Save(SceneManager.GetActiveScene().buildIndex); //saving the current scene, not the next one
        //SaveSystem.instance.SaveOptions(); //save options when closing the options menu

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        SceneManager.LoadScene(0);
    }

    /// Options Window
	public void Options() //from menu to options
    {
        //SaveSystem.instance.LoadOptions(); //load options when entering options menu

        //fullscreenToggle.isOn = SaveSystem.instance.isFulscreen;
        Screen.fullScreen = fullscreenToggle.isOn;

        //musicSlider.value = SaveSystem.instance.music;
        GetComponent<AudioSource>().volume = musicSlider.value;

        Buttons.SetActive(false); //to make sure you can't click them while in the options menu
        OptionsWindow.SetActive(true); //options menu
        OptionsButtons.SetActive(true);

        EventSystem.current.SetSelectedGameObject(OptionsButtons.transform.GetChild(0).gameObject);
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
        //SaveSystem.instance.SaveOptions(); //save options when closing the options menu

        OptionsWindow.SetActive(false);
        OptionsButtons.SetActive(false);

        Buttons.SetActive(true);

        EventSystem.current.SetSelectedGameObject(Buttons.transform.GetChild(0).gameObject);
    }

    public void ResetOptionsDefault()
    {
        fullscreenToggle.isOn = true;
        Screen.fullScreen = true;

        musicSlider.value = musicSlider.maxValue;
        GetComponent<AudioSource>().volume = musicSlider.maxValue;
    }
}