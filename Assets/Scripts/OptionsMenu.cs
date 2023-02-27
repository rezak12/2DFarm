//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using TMPro;

public class OptionsMenu : MonoBehaviour
{
    //public Resolution[] resolutions;
    //public TMP_Dropdown resolutionDropdown;
    public AudioMixer audioMixer;

    private void Start()
    {
        //resolutions = Screen.resolutions;
        //resolutionDropdown.ClearOptions();

        //List<string> resolutionInString = new List<string>();
        //int currentResolutionIndex = 0;
        //for (int i = 0; i < resolutions.Length; i++)
        //{
        //    string option = resolutions[i].width + " x " + resolutions[i].height;
        //    resolutionInString.Add(option);

        //    if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        //    {
        //        currentResolutionIndex = i;
        //    }
        //}

        //resolutionDropdown.AddOptions(resolutionInString);
        //resolutionDropdown.value = currentResolutionIndex;
        //resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //public void SetFullScreen(bool isFullScreen)
    //{
    //    Screen.fullScreen = isFullScreen;
    //}

    //public void SetResolution(int resolutionIndex)
    //{
    //    Resolution resolution = resolutions[resolutionIndex];
    //    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    //}
}
