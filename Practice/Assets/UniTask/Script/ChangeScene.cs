using UnityEngine;
using System.Threading;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] LoadSceneManager _loadSceneManager = default;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneChange();
        }
    }
    private void SceneChange()
    {
        _loadSceneManager.ChangeScene("GameScene");
    }
}
