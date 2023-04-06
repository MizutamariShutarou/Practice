using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePresenter : MonoBehaviour
{
    public abstract void Initialize();

    public abstract void Bind();

    public abstract void Release();
}
