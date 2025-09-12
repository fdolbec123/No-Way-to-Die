using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Audio;
//using UnityEditor.Localization.Editor;

public class MainMenuScript : MonoBehaviour
{
    //vars:
    [Header("GameObjects")]
    public TMP_Dropdown languageMenu;
    public Toggle subtitlesChoice;
    public Toggle vocabularyChoice;
    public Slider volumeSlider;
    public AudioMixer mixer;

    //private vars:
    private int useSubs;
    private int matureVocabulary;
    private float masterVolumeValue;

    [Header("View Data here (DEBUG): ")]
    public DataToSave DataToSaveObject = new DataToSave();




// -------------------------------------------------------------------
    
    //Script for play button:
    public void PlayGame()
    {
        DataToSaveObject = SaveSystemScript.Load(); // We load the saved data (in json format) into an object
        if (JsonUtility.ToJson(DataToSaveObject) != "") // If the object is not an empty json, which it should always be the case, do the following:
        {
            Debug.Log("Here is the value of the level to go to: " + DataToSaveObject.levelToGo);
            if (DataToSaveObject.levelToGo == 0) // 0 = Intro level
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (DataToSaveObject.levelToGo == 1) // This if statement is here to prevent the game from crashing in case the save file contains that value (that level doesn't exist yet)
            {
                Debug.Log("Intro ended!");
            }
        }
    }

    //Script when starting the game
    public void Start()
    {

        useSubs = PlayerPrefs.GetInt("useSubtitles"); // Get value in PlayerPrefs to see if we enable subs (0 = no, 1 = yes)
        if (useSubs == 1)
        {
            subtitlesChoice.isOn = true;
        }
        if (useSubs == 0)
        {
            subtitlesChoice.isOn = false;
        }


        matureVocabulary = PlayerPrefs.GetInt("useMatureVocabulary"); // Same process than the subs value, but for the vocabulary choice
        if (matureVocabulary == 1)
        {
            vocabularyChoice.isOn = true;
        }
        if (matureVocabulary == 0)
        {
            vocabularyChoice.isOn = false;
        }


        masterVolumeValue = PlayerPrefs.GetFloat("MasterVolumeValue"); // Getting a float value corresponding to the slider value for the volume prefs in PlayerPrefs
        if (masterVolumeValue == 0) // This means that the player is playing for the first time! Setting the master volume to 0dB.
        {
            volumeSlider.SetValueWithoutNotify(1f);
            mixer.SetFloat("MasterParameter", Mathf.Log10(volumeSlider.value) * 80); // MasterParameter is the name of the expose volume slider for the Master bus.

        }
        if (masterVolumeValue != 0) // This means that the player already have a value set, setting the slider and the fader to the right value.
        {
            volumeSlider.SetValueWithoutNotify(masterVolumeValue);
            mixer.SetFloat("MasterParameter", Mathf.Log10(volumeSlider.value) * 80); //This line sets the fader to the corresponding dB.
        }

        //Following lines sets the value of the dropbox value to the corresponding existing localization choice.
        var selectedLocale = LocalizationSettings.SelectedLocale;
        var availableLocales = LocalizationSettings.AvailableLocales.Locales;
        int index = availableLocales.IndexOf(selectedLocale);
        languageMenu.SetValueWithoutNotify(index);

        // Adding a AddListener event(?) so the changes of the slider value gets reflected in real time to the volume fader
        volumeSlider.onValueChanged.AddListener(SetMasterVolume);
    }
    void SetMasterVolume(float audioValue)
    {
        mixer.SetFloat("MasterParameter", Mathf.Log10(audioValue)*80); // Applying the change detected by the AddListener
    }


    //Script for the options panel:
    public void SaveSettings()
    {
        //volume slider code
        Debug.Log(volumeSlider.value);
        masterVolumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("MasterVolumeValue", masterVolumeValue);

        //Language selction code
        Debug.Log(languageMenu.value);
        //languageMenu.value is an Int. If the locale table is in the same order as the dropdown menu, the Int value will be matching, so we can use it.
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageMenu.value];

        //Subtitles selection code (see Start methods for more info for values)
        Debug.Log(subtitlesChoice.isOn);
        if (subtitlesChoice.isOn == true)
        {
            useSubs = 1;
        }
        else
        {
            useSubs = 0;
        }
        Debug.Log(useSubs);
        PlayerPrefs.SetInt("useSubtitles", useSubs);

        //vocabulary selection code (see Start methods for more info for values)
        Debug.Log(vocabularyChoice.isOn);
        if (vocabularyChoice.isOn == true)
        {
            matureVocabulary = 1;
        }
        else
        {
            matureVocabulary = 0;
        }
        Debug.Log(matureVocabulary);
        PlayerPrefs.SetInt("useMatureVocabulary", matureVocabulary);

        //We then save user's prefs
        Debug.Log("Saving...");
        PlayerPrefs.Save(); //Saving the Player preferencs in Unity built-in system
    }


    //Script that close the game:
    public void QuitGame()
    {
        Application.Quit();
    }

}
