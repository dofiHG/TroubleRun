using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

public class MenuActions : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isMenuOpen = false;

    private void Start()
    {
        GameObject.Find("Camera Holder").GetComponent<CameraManager>().mouseSpeed = YandexGame.savesData.sentitivity;
        GameObject.Find("PercentSecitivityTxT").GetComponent<TMP_Text>().text = $"{YandexGame.savesData.sentitivity.ToString()}%";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen) { CloseMainMenu(); isMenuOpen = false; }
            else { pausePanel.SetActive(true); Time.timeScale = 0; isMenuOpen = true; }
        }
    }

    public void ChangeVolume(AudioSource sound)
    {
        sound.volume = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Slider>().value/100;
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
        YandexGame.SaveProgress();
    }
}
