using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class EntryPresenter : MonoBehaviour
{
    [SerializeField] BasePresenter[] _presenter;

    private async void Awake()
    {
        foreach(var presenter in _presenter)
        {
            var ct = this.GetCancellationTokenOnDestroy();
            await presenter.Initialize(ct);
            presenter.Bind();
        }
    }
}
