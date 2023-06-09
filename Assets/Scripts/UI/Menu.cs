using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu Instance;

    [SerializeField] private GameObject movementText;

    public GameObject MainMenu;

    public GameObject MainButtons;
    [Space]
    public GameObject OptionsWindow;
    public GameObject OptionsButtons;
    [Space]
    public Animator playerAnimator;
    public Animator blackscreen;
    [Space]
    public Transform beginPosition;
    public GameObject player;

    [Space]

    public Toggle fullscreenToggle;

    public AudioSource scream; //aaahhh !!
    public AudioSource music; //musica
    public AudioSource[] sounds;

    public Slider musicSlider;
    [Space]
    public bool isMenuActive = true;

    private void Start()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        Cursor.lockState = CursorLockMode.Confined;

        //assign all variables to prevent errors
        scream = GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        playerAnimator = PlayerController.Instance.playerAnimator;

        if (SceneManager.GetActiveScene().buildIndex != 0) //not in menu scene
        {
            Cursor.visible = false;

            PlayerController.Instance.lockMovements = false;

            MainMenu.SetActive(false);
            MainButtons.SetActive(false);

            OptionsWindow.SetActive(false);
            OptionsButtons.SetActive(false);

            isMenuActive = false;

            blackscreen.SetBool("transiActive", true);
            blackscreen.SetBool("transiActive", false);
        }
        else //in menu scene
        {
            Cursor.visible = true;

            PlayerController.Instance.lockMovements = true;

            playerAnimator.SetBool("isPriority", true);

            //to make sure there is no problem on start
            MainMenu.SetActive(true);
            MainButtons.SetActive(true);

            OptionsWindow.SetActive(false);
            OptionsButtons.SetActive(true);

            isMenuActive = true;
            
            blackscreen.SetBool("transiActive", false); 
            
            EventSystem.current.SetSelectedGameObject(MainButtons.transform.GetChild(0).gameObject);
        }
	}

    public void StartGame() //new game or continue from save
    {
        OptionsWindow.SetActive(false);
        OptionsButtons.SetActive(false);
        MainButtons.SetActive(false);
        MainMenu.SetActive(false);

        SaveSystem.instance.Load();

        scream.Play();

        //SceneManager.LoadScene(SaveSystem.instance._lvl);

        playerAnimator.SetBool("isScared", true);

        StartCoroutine(LockMovementBeginning());
    }

    IEnumerator LockMovementBeginning()
    {
        yield return new WaitForSeconds(5.5f);

        isMenuActive = false;

        PlayerController.Instance.lockMovements = false;

        PlayerController.Instance.speed = PlayerController.Instance.speedDefault;
        PlayerController.Instance.speedValue = PlayerController.Instance.speedDefault;
        PlayerController.Instance.jumpSpeed = PlayerController.Instance.jumpDefault;

        movementText.SetActive(true);
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
        //SaveSystem.instance.LoadOptions(); //load options when entering options menu

        //fullscreenToggle.isOn = SaveSystem.instance.isFulscreen;
        Screen.fullScreen = fullscreenToggle.isOn;

        //musicSlider.value = SaveSystem.instance.music;
        scream.volume = musicSlider.value;

        MainButtons.SetActive(false); //to make sure you can't click them while in the options menu

        OptionsWindow.SetActive(true); //options menu
        OptionsButtons.SetActive(true); //options buttons

        EventSystem.current.SetSelectedGameObject(OptionsButtons.transform.GetChild(0).gameObject);
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
    }

    public void VolumeSlider()
    {
        scream.volume = musicSlider.value;
        music.volume = musicSlider.value;

        for(int i = 0; i <= sounds.Length; i++)
        {
            sounds[i].volume = musicSlider.value;
        }
	}

    public void SensitivitySlider()
    {
        //you have to make a virtual mouse cursor to change the sensitivity
    }

    public void OptionsBack() //from options back to the main menu
    {
        //SaveSystem.instance.SaveOptions(); //save options when closing the options menu

        OptionsWindow.SetActive(false);

        MainButtons.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(MainButtons.transform.GetChild(0).gameObject);
    }

    public void ResetOptionsDefault()
    {
        fullscreenToggle.isOn = true;
        Screen.fullScreen = true;

        musicSlider.value = musicSlider.maxValue;
        scream.volume = musicSlider.maxValue;
    }
}
