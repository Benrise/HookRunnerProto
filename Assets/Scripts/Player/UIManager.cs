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



    void Start(){
        pm = GetComponent<PlayerMovement>();
        Time.timeScale = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        pm.isGameStopped = true;
        GUI.SetActive(false);
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
