using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputForMove : MonoBehaviour
{
    /// <summary>
    /// íçì¸Ç≈Ç´ÇÈÇÊÇ§Ç…ÇµÇƒÇ®Ç≠
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
