using UnityEngine;
using System.Threading;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] LoadSceneManager _loadSceneManager;

    CancellationTokenSource _cts;

    CancellationToken _ct;
    private void Start()
    {
        _cts = new CancellationTokenSource();
        _ct = _cts.Token;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneChange();
        }
    }
    private void SceneChange()
    {
        _loadSceneManager.ChangeScene("GameScene", _ct);
    }
}
