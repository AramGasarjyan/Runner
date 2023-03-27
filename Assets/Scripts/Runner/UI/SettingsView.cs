using System.Collections.Generic;
using DefaultNamespace.Runner.UI;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView : AbstractView
{
    [SerializeField] Toggle _easyToggle;
    [SerializeField] Toggle _mediumToggle;
    [SerializeField] Toggle _hardToggle;
    [SerializeField] Toggle _soundToggle;
    [SerializeField] Button _menuButton;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Road _road;
    [SerializeField] AudioSource _musicAudio;

    private List<Toggle> _difficultyToggles = new();

    protected override void OnEnable()
    {
        _difficultyToggles.Add(_easyToggle);
        _difficultyToggles.Add(_mediumToggle);
        _difficultyToggles.Add(_hardToggle);

        OnMediumToggleClicked(true);

        _easyToggle.onValueChanged.AddListener(OnEasyToggleClicked);
        _mediumToggle.onValueChanged.AddListener(OnMediumToggleClicked);
        _hardToggle.onValueChanged.AddListener(OnHardToggleClicked);
        _soundToggle.onValueChanged.AddListener(OnSoundToggleClicked);

        _menuButton.onClick.AddListener(OnMenuButtonCliked);
    }

    protected override void OnDisable()
    {
        _easyToggle.onValueChanged.RemoveListener(OnEasyToggleClicked);
        _mediumToggle.onValueChanged.RemoveListener(OnMediumToggleClicked);
        _hardToggle.onValueChanged.RemoveListener(OnHardToggleClicked);
        _soundToggle.onValueChanged.RemoveListener(OnSoundToggleClicked);
    }

    public override void Init()
    {

    }

    public void Show(bool value)
    {
        gameObject.SetActive(value);
    }

    private void OnMenuButtonCliked()
    {
        Show(false);
    }

    private void OnEasyToggleClicked(bool value)
    {
        DeactivateDifficultyToggles(_easyToggle);
        _playerMovement.SetMovementSpeed(3);
        _road.SetFillPercent(0.3f);
    }
    private void OnMediumToggleClicked(bool value)
    {
        DeactivateDifficultyToggles(_mediumToggle);
        _playerMovement.SetMovementSpeed(5);
        _road.SetFillPercent(0.5f);
    }
    private void OnHardToggleClicked(bool value)
    {
        DeactivateDifficultyToggles(_hardToggle);
        _playerMovement.SetMovementSpeed(7);
        _road.SetFillPercent(0.7f);
    }
    private void OnSoundToggleClicked(bool value)
    {
        _musicAudio.mute = !value;
    }

    private void DeactivateDifficultyToggles(Toggle stayOnFortoggle)
    {
        foreach (var item in _difficultyToggles)
        {
            if (item == stayOnFortoggle)
            {
                continue;
            }
           item.isOn = false;
        }
    }
}
