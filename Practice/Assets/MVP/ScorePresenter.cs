using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace UniRxMVPSample
{
    /// <summary>
    /// Modelのデータ処理とViewの見た目の処理を仲介。
    /// </summary>
    public class ScorePresenter : BasePresenter
    {
        [SerializeField] ScoreModel _model;
        [SerializeField] ScoreView _view;

        [SerializeField] int _initScore = 0;

        public override async UniTask Initialize(CancellationToken ct)
        {
            _model = new ScoreModel(_initScore);
            _view.Initialize();
            _view.ShowScoreText(_initScore);

            await UniTask.CompletedTask;
        }

        public override void Bind()
        {
            _model.CurrentScore
                .Subscribe(ChangeScore)
                .AddTo(gameObject);
        }

        public override void Release()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 購読者。CurrentScoreの変更通知が来たらこの関数を呼ぶ。
        /// </summary>
        /// <param name="CurrentScore"></param>
        private void ChangeScore(int CurrentScore)
        {
            _view.ShowScoreText(CurrentScore);
        }
        
        /// <summary>
        /// Scoreを増やす処理。別のクラスから呼ぶ。
        /// </summary>
        /// <param name="addScore"></param>
        public void AddScore(int addScore)
        {
            _model.AddScore(addScore);
        }

        public void ResetScore()
        {
            _model.ResetScore();
        }
    }

}


