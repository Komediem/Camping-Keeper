using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu Instance;

    public GameObject MainMenu;

    public GameObject MainButtons;
    public GameObject OptionsWindow;

    [Space]

    public Toggle fullscreenToggle;

    public new AudioSource audio; //musica !!
    public Slider musicSlider;

    public bool isMenuActive = true;

    private void Start() 
    {
        if (Instance) Destroy(this);
        else Instance = this;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerController.Instance.lockMovements = true;

            //to make sure there is no problem on start
            MainMenu.SetActive(true);
            MainButtons.SetActive(true);
            OptionsWindow.SetActive(false);

            Cursor.lockState = CursorLockMode.Confined;

            isMenuActive = true;
        }
        else
        {
            MainMenu.SetActive(false);
            MainButtons.SetActive(false);
            OptionsWindow.SetActive(false);

            isMenuActive = false;

            PlayerController.Instance.lockMovements = false;
        }
    }

    public void StartGame() //new game or continue from save
    {
        OptionsWindow.SetActive(false);
        MainButtons.SetActive(false);
        MainMenu.SetActive(false);

        SaveSystem.instance.Load();

        //SceneManager.LoadScene(SaveSystem.instance._lvl);

        isMenuActive = false;

        PlayerController.Instance.lockMovements = false;
    }

    public void ExitGame() //close App
     {
        isMenuActive = false;

        Application.OpenURL("https://artfx.school/");

        Application.Quit();
     }

    /// Options Window
	public void Options() //from menu to options
    {
        SaveSystem.instance.LoadOptions(); //load options when entering options menu

        fullscreenToggle.isOn = SaveSystem.instance.isFulscreen;
        Screen.fullScreen = SaveSystem.instance.isFulscreen;

        musicSlider.value = SaveSystem.instance.music;
        audio.volume = SaveSystem.instance.music;

        MainButtons.SetActive(false); //to make sure you can't click them while in the options menu
        OptionsWindow.SetActive(true); //options menu

        //EventSystem.current.SetSelectedGameObject(OptionsWindow.transform.GetChild(0).gameObject);
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
    }

    public void VolumeSlider()
    {
        audio.volume = musicSlider.value;
    }

    public void SensitivitySlider()
    {
        //you have to make a virtual mouse cursor to change the sensitivity
    }

    public void OptionsBack() //from options back to the main menu
    {
        SaveSystem.instance.SaveOptions(); //save options when closing the options menu

        OptionsWindow.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void ResetOptionsDefault()
    {
        fullscreenToggle.isOn = true;
        Screen.fullScreen = true;

        musicSlider.value = musicSlider.maxValue;
        audio.volume = musicSlider.maxValue;
    }
}
