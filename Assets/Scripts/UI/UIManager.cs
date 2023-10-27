using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject GUI;
    public GameObject PauseUI;
    private bool _isPauseActive = false;
    private PlayerMovement pm;
    private int highScore;

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        Time.timeScale = 1.0f;

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        pm.isGameStopped = true;
        GUI.SetActive(false);

        int currentScore = pm.score;
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
        }
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
        if (GameOverUI.activeSelf) return;
        _isPauseActive = true;
        PauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        pm.isGameStopped = true;
    }

    public void ClosePauseMenu()
    {
        _isPauseActive = false;
        PauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        pm.isGameStopped = false;
    }
}
