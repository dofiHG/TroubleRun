using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

public class MenuActions : MonoBehaviour
{
    public GameObject pausePanel;
    public Sprite[] languages;

    private bool isMenuOpen = false;
    private int languageInt;

    private void Start()
    {
        GameObject.Find("Camera Holder").GetComponent<CameraManager>().mouseSpeed = YandexGame.savesData.sentitivity;
        GameObject.Find("Music").GetComponent<AudioSource>().volume = YandexGame.savesData.musicVolume;
        GameObject.Find("Music").GetComponent<AudioSource>().volume = YandexGame.savesData.environmentVolume;
        GameObject.Find("Music").GetComponent<AudioSource>().volume = YandexGame.savesData.effectsVolume;
        languageInt = YandexGame.savesData.usersLanguage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen) { CloseMainMenu(); isMenuOpen = false; }
            else 
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                isMenuOpen = true;

                GameObject.Find("LanguageIMG").GetComponent<Image>().sprite = languages[languageInt];

                EventSystem.current.SetSelectedGameObject(GameObject.Find("SoundSlider"));
                GameObject.Find("PercentSoundTxT").GetComponent<TMP_Text>().text = $"{YandexGame.savesData.musicVolume}%";
                GameObject.Find("SoundSlider").GetComponent<Slider>().value = YandexGame.savesData.musicVolume;

                EventSystem.current.SetSelectedGameObject(GameObject.Find("EnvironmestSoundSlider"));
                GameObject.Find("PercentEnironmentTxT").GetComponent<TMP_Text>().text = $"{YandexGame.savesData.environmentVolume}%";
                GameObject.Find("EnvironmestSoundSlider").GetComponent<Slider>().value = YandexGame.savesData.environmentVolume;

                EventSystem.current.SetSelectedGameObject(GameObject.Find("EffectsSoundSlider"));
                GameObject.Find("PercentEffectsTxT").GetComponent<TMP_Text>().text = $"{YandexGame.savesData.effectsVolume}%";
                GameObject.Find("EffectsSoundSlider").GetComponent<Slider>().value = YandexGame.savesData.effectsVolume;

                EventSystem.current.SetSelectedGameObject(GameObject.Find("SencitivitySlider"));
                GameObject.Find("PercentSecitivityTxT").GetComponent<TMP_Text>().text = $"{YandexGame.savesData.sentitivity}%";
                GameObject.Find("SencitivitySlider").GetComponent<Slider>().value = YandexGame.savesData.sentitivity;
            }
        }
    }

    public void ChangeVolume(AudioSource sound)
    {
        sound.volume = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Slider>().value / 100;
    }

    public void ChangePercentVolume(TMP_Text text)
    {
        text.text = $"{EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Slider>().value}%";
    }

    public void ChangeSencitivity()
    {
        GameObject.Find("Camera Holder").GetComponent<CameraManager>().mouseSpeed =
            EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Slider>().value;
    }

    public void CloseMainMenu()
    {
        SaveButton();
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        isMenuOpen = false;
    }

    public void SaveButton()
    {
        YandexGame.savesData.musicVolume = GameObject.Find("SoundSlider").GetComponent<Slider>().value;
        YandexGame.savesData.environmentVolume = GameObject.Find("EnvironmestSoundSlider").GetComponent<Slider>().value;
        YandexGame.savesData.effectsVolume = GameObject.Find("EffectsSoundSlider").GetComponent<Slider>().value;
        YandexGame.savesData.sentitivity = GameObject.Find("SencitivitySlider").GetComponent<Slider>().value;
        YandexGame.savesData.usersLanguage = languageInt;
        YandexGame.SaveProgress();
    }

    public void LanguageChange()
    {
        languageInt += 1;
        if (languageInt > 3) { languageInt = 0; }
        GameObject.Find("LanguageIMG").GetComponent<Image>().sprite = languages[languageInt];
        SaveButton();
    }
}
