using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxMVPSample
{
    /// <summary>
    /// Model�̃f�[�^������View�̌����ڂ̏����𒇉�B
    /// </summary>
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] ScoreModel _model;
        [SerializeField] ScoreView _view;

        [SerializeField] int _initScore = 0;

        /// <summary>
        /// Model��View�̏��������Ă�
        /// </summary>
        void Start()
        {
            // �R���X�g���N�^���C���X�^���X��
            _model = new ScoreModel(_initScore);
            _view.Initialize();
            _view.ShowScoreText(_initScore);

            Bind();

        }

        /// <summary>
        /// Model��View�̃f�[�^�����ѕt����
        /// </summary>
        private void Bind()
        {
            // �w�ǎ҂�o�^(�Ď��̑Ώۂ�CurrentScore�̒l���ς������Subscribe�����֐����Ă�)
            _model.CurrentScore
                .Subscribe(ChangeScore)
                .AddTo(gameObject);
        }

        /// <summary>
        /// �w�ǎҁBCurrentScore�̕ύX�ʒm�������炱�̊֐����ĂԁB
        /// </summary>
        /// <param name="CurrentScore"></param>
        private void ChangeScore(int CurrentScore)
        {
            _view.ShowScoreText(CurrentScore);
        }
        
        /// <summary>
        /// Score�𑝂₷�����B�ʂ̃N���X����ĂԁB
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


