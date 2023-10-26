using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Application.Quit());
    }
}
