using System;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsOperator : SinglBehaviour<OptionsOperator>
{
    [SerializeField]
    private AudioMixerGroup mixerMasterGroup;
    [SerializeField]
    public Slider sensitivitySlider;
    [SerializeField]
    public Slider volumeSlider;
    [SerializeField]
    private AnimationCurve curve;

    private static bool OnLoad;

    public void Return()
    {
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.SwitchPanels(SceneDirection.exit);
    }

    public void Apply()
    {

    }
    public void RestoreDefault()
    {

    }
    public void FullScreen(Toggle toggle)
    {
        OptionsManager.FullScreen = toggle.isOn;
    }
    public void ScreenResolution(Dropdown dropdown)
    {
        OptionsManager.CurrentResolution = OptionsManager.ScreenResolution.FullHD;
    }

    public void MouseSensitivity()
    {

    }

    public void MasterVolume()
    {
        if (instance == null)
            return;

        float volume = Mathf.Lerp(-80f, 0, curve.Evaluate(GetVolume()));

        mixerMasterGroup.audioMixer.SetFloat("MasterVolume", volume);
        if (!OnLoad)
            SaveManager.SaveOptions();
    }

    public static float GetVolume()
    {
        if (instance == null)
            return default;

        //volumeSlider minValue = -1, minValue = 1
        return instance.volumeSlider.value / 2 + .5f;
    }

    public void Language()
    {
        if (instance == null)
            return;

        PlayerManager.Language = 0;

        if (!OnLoad)
            SaveManager.SaveOptions();
    }

    public static OptionsParameters GetParameters()
    {
        return new OptionsParameters(false, 0, instance.volumeSlider.value, 0.5f, 0);
    }

    public static void LoadOptions()
    {
        if (instance == null)
            return;

        OnLoad = true;
        var parametrs = SaveManager.LoadOptions();
        //fullScreen = parametrs.fullScreen;
        instance.volumeSlider.value = parametrs.volume;
        instance.sensitivitySlider.value = parametrs.sensitivit;
        //Language = parametrs.language;
        OnLoad = false;
    }
}

[Serializable]
public struct OptionsParameters
{
    public bool fullScreen;
    public int screenResolution;
    public float volume;
    public float sensitivit;
    public int language;

    public OptionsParameters(bool fullScreen, int screenResolution, float volume, float sensitivit, int language)
    {
        this.fullScreen = fullScreen;
        this.screenResolution = screenResolution;
        this.volume = volume;
        this.sensitivit = sensitivit;
        this.language = language;
    }
}