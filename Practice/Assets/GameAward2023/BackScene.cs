using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    public void Change()
    {
        NewMeshManager._isFinished = false;
        SceneManager.LoadScene("GameAwardTest");
    }
}
