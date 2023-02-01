using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniRxMVPSample
{
    public class Player : MonoBehaviour
    {
        [SerializeField] ScorePresenter _presenter;

        [SerializeField] int _addScore;
        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _presenter.AddScore(_addScore);
            }
            if(Input.GetMouseButtonDown(1))
            {
                _presenter.ResetScore();
            }
        }
    }

}

