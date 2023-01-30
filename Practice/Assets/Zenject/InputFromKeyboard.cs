using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFromKeyboard : IInputtable
{
    /// <summary>
    /// ��ɂ��̃��\�b�h�̒l������̂ł͂Ȃ��K�v�ɂȂ����^�C�~���O��
    /// ���̃��\�b�h��InputForMove�N���X��IInputtable�ϐ��ɒ�������
    /// </summary>
    /// <returns></returns>
    public Vector3 InputForMove()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
}
