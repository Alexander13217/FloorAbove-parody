using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;

    public void LoadScene()
    {
        SceneManager.LoadScene(_scene.name);
    }
}
