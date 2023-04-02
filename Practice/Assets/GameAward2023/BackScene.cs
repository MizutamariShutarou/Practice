using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("GameAwardTest");
    }
}
