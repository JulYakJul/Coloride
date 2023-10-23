using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalButton : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Normal");
    }
}
