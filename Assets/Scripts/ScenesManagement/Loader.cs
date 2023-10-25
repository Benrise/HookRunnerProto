using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene {
        GameScene,
        MenuScene
    }

    public static void LoadScene(Scene scene){
        SceneManager.LoadScene(scene.ToString());
    }
    
}
