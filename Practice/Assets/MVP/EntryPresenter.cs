using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPresenter : MonoBehaviour
{
    [SerializeField] BasePresenter[] _presenter;

    private void Awake()
    {
        foreach(var presenter in _presenter)
        {
            presenter.Initialize();
        }
    }
}
