using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _start;
    [SerializeField] private Button _option;
    [SerializeField] private Button _leave;
    [SerializeField] private Button _help;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private Button _back;
    [SerializeField] private Button _back2;
    [SerializeField] private TextMeshProUGUI _volumeText;
    [SerializeField] private TextMeshProUGUI _effectText;
    [SerializeField] private Button _volumeMute;
    [SerializeField] private Button _effectMute;
    
    void Awake()
    {
        _volumeSlider.value = 0.75f;
        _effectsSlider.value = 0.75f;
        VolumeSliderChanged(_volumeSlider.value);
        EffectsSliderChanged(_effectsSlider.value);
        Open_Main_Menu();
        
        
        _start.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySFX("Son_des_Bouttons");
            SceneManager.LoadScene("ConnectToServer");
        });
        
       

        
        _option.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySFX("Son_des_Bouttons");
            Open_option();
        });
        
        
        _help.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySFX("Son_des_Bouttons");
            _option.gameObject.SetActive(false);
            _start.gameObject.SetActive(false);
            _leave.gameObject.SetActive(false);
            _help.gameObject.SetActive(false);
            _volumeSlider.gameObject.SetActive(false);
            _effectsSlider.gameObject.SetActive(false);
            _back.gameObject.SetActive(false);
            _back2.gameObject.SetActive(true);
            _volumeText.gameObject.SetActive(false);
            _effectText.gameObject.SetActive(false);
            _effectMute.gameObject.SetActive(false);
            _volumeMute.gameObject.SetActive(false);
        
        });

        _back.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySFX("Son_des_Bouttons");
            Open_Main_Menu();
        });
        
        
        _back2.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySFX("Son_des_Bouttons");
            Open_option();
        });


        _leave.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySFX("Son_des_Bouttons");
            Application.Quit();
        });

        _volumeSlider.onValueChanged.AddListener(VolumeSliderChanged);
        _effectsSlider.onValueChanged.AddListener(EffectsSliderChanged);
    }

    private void Open_Main_Menu()
    {
        _option.gameObject.SetActive(true);
        _start.gameObject.SetActive(true);
        _leave.gameObject.SetActive(true);
        _help.gameObject.SetActive(false);
        _volumeSlider.gameObject.SetActive(false);
        _effectsSlider.gameObject.SetActive(false);
        _back.gameObject.SetActive(false);
        _back2.gameObject.SetActive(false);
        _volumeText.gameObject.SetActive(false);
        _effectText.gameObject.SetActive(false);
        _effectMute.gameObject.SetActive(false);
        _volumeMute.gameObject.SetActive(false);
    }

    private void Open_option()
    {
        _option.gameObject.SetActive(false);
        _start.gameObject.SetActive(false);
        _leave.gameObject.SetActive(false);
        _help.gameObject.SetActive(true);
        _volumeSlider.gameObject.SetActive(true);
        _effectsSlider.gameObject.SetActive(true);
        _back.gameObject.SetActive(true);
        _back2.gameObject.SetActive(false);
        _volumeText.gameObject.SetActive(true);
        _effectText.gameObject.SetActive(true);
        _effectMute.gameObject.SetActive(true);
        _volumeMute.gameObject.SetActive(true);
    }
    private void VolumeSliderChanged(float value)
    {
        _volumeText.text = $"Volume :  {Mathf.RoundToInt(value * 100)} %";
    }
    
    private void EffectsSliderChanged(float value)
    {
        _effectText.text = $"Effets Sonores :  {Mathf.RoundToInt(value * 100)} %";
    }
}