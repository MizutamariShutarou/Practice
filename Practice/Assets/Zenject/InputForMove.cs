using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputForMove : MonoBehaviour
{
    /// <summary>
    /// �����ł���悤�ɂ��Ă���
    /// </summary>
    [Inject]
    private IInputtable _inputObject;

    void Update()
    {
        if(_inputObject != null)
        {
            Move(_inputObject.InputForMove());
        }
    }

    private void Move(Vector3 vec)
    {
        var position = transform.localPosition;
        transform.localPosition = position + vec;
    }
}
