using UnityEngine;

[CreateAssetMenu]
public class IdleState : State
{
    protected override void Enter()
    {
        Debug.Log("アイドル開始");
    }

    protected override void Exit()
    {
        // Debug.Log("アイドルおわり");
    }

    protected override void Update()
    {
        // Debug.Log("アイドルなう");
    }
}
