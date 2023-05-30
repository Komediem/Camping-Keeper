using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu Instance;

    public Toggle fullscreenToggle;

    public new AudioSource audio; //musica !!
    public Slider musicSlider;

    public GameObject Buttons;
    public GameObject OptionsWindow;

    private void Start() 
    {
        if (Instance) Destroy(this);
        else Instance = this;

        //to make sure there is no problem on start
        Buttons.SetActive(true);
        OptionsWindow.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        EventSystem.current.SetSelectedGameObject(Buttons.transform.GetChild(0).gameObject);
    }

    public void StartGame() //new game or continue from save
    {
        SaveSystem.instance.Load();

        SceneManager.LoadScene(SaveSystem.instance._lvl);
    }

     public void ExitGame() //close App
     {
        Application.Quit();
     }

    /// Options Window
	public void Options() //from menu to options
    {
        SaveSystem.instance.LoadOptions(); //load options when entering options menu

        fullscreenToggle.isOn = SaveSystem.instance.isFulscreen;
        Screen.fullScreen = SaveSystem.instance.isFulscreen;

        musicSlider.value = SaveSystem.instance.music;

        Buttons.SetActive(false); //to make sure you can't click them while in the options menu
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
        Buttons.SetActive(true);
    }

    public void ResetOptionsDefault()
    {
        fullscreenToggle.isOn = true;
        Screen.fullScreen = true;

        musicSlider.value = musicSlider.maxValue;
    }
}
