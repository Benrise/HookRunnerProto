using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {Loader.LoadScene(Loader.Scene.MenuScene);});
    }
}
