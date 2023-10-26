using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => Loader.LoadScene(Loader.Scene.GameScene));  
    }
}
