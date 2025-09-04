using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Settings;
//using UnityEditor.Localization.Editor;

public class MainMenuScript : MonoBehaviour
{
    //vars:
    public TMP_Dropdown languageMenu;
    public Toggle subtitlesChoice;
    public Toggle vocabularyChoice;
    public Slider volumeSlider;
    private int useSubs;
    private int matureVocabulary;
    //Script for play button:
    public void PlayGame()
    {
        Debug.Log("Button pressed!");
        // Showing this only for Debuging purposes.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Script when starting the game
    public void Start()
    {
        useSubs = PlayerPrefs.GetInt("useSubtitles");
        if (useSubs == 1)
        {
            subtitlesChoice.isOn = true;
        }
        if (useSubs == 0)
        {
            subtitlesChoice.isOn = false;
        }
        matureVocabulary = PlayerPrefs.GetInt("useMatureVocabulary");
        if (matureVocabulary == 1)
        {
            vocabularyChoice.isOn = true;
        }
          if (matureVocabulary == 0)
        {
            vocabularyChoice.isOn = false;
        }
        
    }

    //Script for the options panel:
    public void SaveSettings()
    {
        //volume slider code
        Debug.Log(volumeSlider.value);

        //Language selction code
        Debug.Log(languageMenu.value);
        //languageMenu.value is an Int. If the locale table is in the same order as the dropdown menu, the Int value will be matching, so we can use it.
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageMenu.value];

        //Subtitles selection code
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

        //vocabulary selection code
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
        PlayerPrefs.Save();
    }


    //Script that close the game:
    public void QuitGame()
    {
        Application.Quit();
    }

}
