using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour {

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;

    private void Awake() {
        resumeButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();

        });

        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);

        });
        optionsButton.onClick.AddListener(() => {
            Hide();
            OptionsUI.Instance.Show(Show);
        });
    }

    private void Start() {
        KitchenGameManager.Instance.OnGamePaused += Instance_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += Instance_OnGameUnpaused;

        Hide();
    }

    private void Instance_OnGameUnpaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void Instance_OnGamePaused(object sender, System.EventArgs e) {
        Show();
    }

    public void Show() {
        gameObject.SetActive(true);

        resumeButton.Select();
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
