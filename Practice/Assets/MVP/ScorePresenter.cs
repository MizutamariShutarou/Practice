using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxMVPSample
{
    /// <summary>
    /// Modelのデータ処理とViewの見た目の処理を仲介。
    /// </summary>
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] ScoreModel _model;
        [SerializeField] ScoreView _view;

        [SerializeField] int _initScore = 0;

        /// <summary>
        /// ModelとViewの初期化を呼ぶ
        /// </summary>
        void Start()
        {
            // コンストラクタをインスタンス化
            _model = new ScoreModel(_initScore);
            _view.Initialize();
            _view.ShowScoreText(_initScore);

            Bind();

        }

        /// <summary>
        /// ModelとViewのデータを結び付ける
        /// </summary>
        private void Bind()
        {
            // 購読者を登録(監視の対象のCurrentScoreの値が変わったらSubscribeした関数を呼ぶ)
            _model.CurrentScore
                .Subscribe(ChangeScore)
                .AddTo(gameObject);
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


