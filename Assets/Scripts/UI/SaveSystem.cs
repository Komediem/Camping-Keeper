using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    #region Options to save
    public float music;
    public bool isFulscreen;

    public Toggle fullScreenToggle;
    public Slider musicSlider;
    #endregion

    public int _lvl;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    public void Save(int scene)
    {
        _lvl = scene;

        string saveFilePath = Application.persistentDataPath + "/save.fsav";
        //print("Saving to : " + saveFilePath);

        JObject jObject = new JObject();
        jObject.Add("Save File", GetType().ToString());

        JObject jDataObject = new JObject();
        jObject.Add("Data", jDataObject);

        jDataObject.Add("Level", _lvl);

        StreamWriter sw = new StreamWriter(saveFilePath);
        sw.WriteLine(jObject.ToString());

        sw.Close();
    }
    public void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "/save.fsav")) //check if there is a save file
        {
            _lvl = 1; //first level of the game ("index 0" is the menu)
        }
        else
        {
            string saveFilePath = Application.persistentDataPath + "/save.fsav";

            StreamReader sr = new StreamReader(saveFilePath);
            string jsonString = sr.ReadToEnd();

            sr.Close();
            JObject jObject = JObject.Parse(jsonString);

            _lvl = (int)jObject["Data"]["Level"];

            //print(jObject.ToString());
        }
    }

    public void SaveOptions()
    {
        isFulscreen = fullScreenToggle.isOn;
        music = musicSlider.value;

        string saveFilePath = Application.persistentDataPath + "/options.fsav";
        //print("Saving to : " + saveFilePath);

        JObject jObject = new JObject();
        jObject.Add("Options Save File", GetType().ToString());

        JObject jOptionsDataObject = new JObject();
        jObject.Add("options data", jOptionsDataObject);

        jOptionsDataObject.Add("Fulscreen", isFulscreen);
        jOptionsDataObject.Add("Music", music);

        StreamWriter sw = new StreamWriter(saveFilePath);
        sw.WriteLine(jObject.ToString());

        sw.Close();
    }

    public void LoadOptions()
    {
        if (!File.Exists(Application.persistentDataPath + "/options.fsav")) //check if there is a save file for the options
        {
            //sets them to default settings
            isFulscreen = true;
            Screen.fullScreen = true;

            music = musicSlider.maxValue;
        }
        else
        {
            string saveFilePath = Application.persistentDataPath + "/options.fsav";

            StreamReader sr = new StreamReader(saveFilePath);
            string jsonString = sr.ReadToEnd();

            sr.Close();
            JObject jObject = JObject.Parse(jsonString);

            isFulscreen = (bool)jObject["options data"]["Fulscreen"];
            music = (float)jObject["options data"]["Music"];
        }

        Screen.fullScreen = isFulscreen;
        fullScreenToggle.isOn = isFulscreen;

        musicSlider.value = music;
    }
}