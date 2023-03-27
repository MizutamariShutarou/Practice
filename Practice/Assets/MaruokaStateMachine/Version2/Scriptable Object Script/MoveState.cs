using UnityEngine;

[CreateAssetMenu]
public class MoveState : State
{
    protected override void Enter()
    {
        Debug.Log("ムーブ開始");
    }

    protected override void Exit()
    {
        // Debug.Log("ムーブおわり");
    }

    protected override void Update()
    {
        // Debug.Log("ムーブなう");
    }
}
