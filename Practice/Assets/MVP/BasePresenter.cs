using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;

public abstract class BasePresenter : MonoBehaviour
{
    public abstract UniTask Initialize(CancellationToken ct);

    public abstract void Bind();

    public abstract void Release();
}
