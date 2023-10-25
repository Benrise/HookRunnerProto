using System;
using UnityEngine.UI;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    public Button PlayButton;
    public Button ScoreBoardButton;

    public Button ExitButton;

    private void Start(){
        PlayButton.onClick.AddListener(() => Loader.LoadScene(Loader.Scene.GameScene));
        ExitButton.onClick.AddListener(() => Application.Quit());
    }

}
