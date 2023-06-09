using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu Instance;

    public GameObject MainMenu;

    public GameObject MainButtons;
    public GameObject OptionsWindow;

    public Animator playerAnimator;
    public Transform beginPosition;
    public GameObject player;

    [Space]

    public Toggle fullscreenToggle;

    public new AudioSource audio; //musica !!
    public Slider musicSlider;

    public bool isMenuActive = true;

    private void Start()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        Cursor.lockState = CursorLockMode.Confined;

        //assign all variables to prevent errors
        audio = GetComponent<AudioSource>();

        MainMenu = GameObject.Find("Main Menu");
        MainButtons = GameObject.Find("MenuBoutons");
        OptionsWindow = GameObject.Find("Options");

        player = GameObject.Find("Player");

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            MainMenu.SetActive(false);
            MainButtons.SetActive(false);
            OptionsWindow.SetActive(false);

            isMenuActive = false;

            PlayerController.Instance.lockMovements = false;
        }
        else
        {
            Cursor.visible = true;

            PlayerController.Instance.lockMovements = true;

            playerAnimator.SetBool("isPriority", true);

            //to make sure there is no problem on start
            MainMenu.SetActive(true);
            MainButtons.SetActive(true);
            OptionsWindow.SetActive(false);

            isMenuActive = true;
        }
    }

    public void StartGame() //new game or continue from save
    {
        OptionsWindow.SetActive(false);
        MainButtons.SetActive(false);
        MainMenu.SetActive(false);

        SaveSystem.instance.Load();

        //SceneManager.LoadScene(SaveSystem.instance._lvl);

        playerAnimator.SetBool("isScared", true);

        isMenuActive = false;

        StartCoroutine(LockMovementBeginning());
    }

    IEnumerator LockMovementBeginning()
    {
        yield return new WaitForSeconds(5.5f);
        PlayerController.Instance.lockMovements = false;
    }

    public void ExitGame() //close App
    {
        isMenuActive = false;

        //Application.OpenURL("https://artfx.school/");

        ScreenCapture.CaptureScreenshot(Application.persistentDataPath + ".png");

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
