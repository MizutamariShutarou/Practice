//using UnityEngine;

//[System.Serializable]
//public class PlayerStateMachine : StateMachineBase
//{
//    [SerializeField] IdleState _idle;

//    [SerializeField] MoveState _move;

//    [SerializeField] JumpState _jump;

//    public IdleState Idle => _idle;
//    public MoveState Move => _move;
//    public JumpState Jump => _jump;

//    PlayerController _controller;

//    public PlayerController Controller => _controller;
//    public void Init(PlayerController playerController)
//    {
//        _controller = playerController;
//        Initialize(_idle);
//    }
//    protected override void StateInit()
//    {
//        _idle = new IdleState(this);
//        _move = new MoveState(this);
//        _jump = new JumpState(this);
//        _idle.Init(this);
//    }
//}
