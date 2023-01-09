using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderUI : MonoBehaviour
{
    public void LoadScene(string scene) => SceneManager.LoadScene(scene);
}
