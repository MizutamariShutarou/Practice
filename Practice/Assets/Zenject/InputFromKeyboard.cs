using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFromKeyboard : IInputtable
{
    /// <summary>
    /// 常にこのメソッドの値を見るのではなく必要になったタイミングで
    /// このメソッドをInputForMoveクラスのIInputtable変数に注入する
    /// </summary>
    /// <returns></returns>
    public Vector3 InputForMove()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
}
