using System.Net.Mime;
using System;
using UnityEngine.UI;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public Button ContinueButton;
    public Button ScoreboardButton;
    public Button RestartButton;
    public Button MenuButton;
    public Button ExitButton;
    public GameObject PauseMenu;

    [SerializeField]
    private bool _isPauseActive = false;

    private void Start(){
        MenuButton.onClick.AddListener(() => Loader.LoadScene(Loader.Scene.MenuScene));
        ExitButton.onClick.AddListener(() => Application.Quit());
        RestartButton.onClick.AddListener(() => Loader.LoadScene(Loader.Scene.GameScene));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPauseActive)
                ClosePauseMenu();
            else
                OpenPauseMenu();
        }
    }

    public void OpenPauseMenu()
    {
        _isPauseActive = true;
        PauseMenu.SetActive(_isPauseActive);
        Time.timeScale = 0.0f;
    }

    public void ClosePauseMenu()
    {
        _isPauseActive = false;
        PauseMenu.SetActive(_isPauseActive);
        Time.timeScale = 1.0f;
    }

}
