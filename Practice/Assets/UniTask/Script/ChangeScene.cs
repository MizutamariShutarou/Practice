using UnityEngine;
using UnityEngine.UI;

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
        Debug.Log("1");
    }
}
