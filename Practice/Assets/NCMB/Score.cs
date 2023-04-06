using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	// �X�R�A��\������GUIText
	public UnityEngine.UI.Text scoreGUIText;

	// �n�C�X�R�A��\������GUIText
	public Text highScoreGUIText;

	// �n�C�X�R�A��\������GUIText
	public UnityEngine.UI.Text saveScoreGUIText = null;

	// �X�R�A
	private int score;

	private NCMB.HighScore highScore;
	private bool isNewRecord;

	// �n�C�X�R�A
	//private int highScore;

	// PlayerPrefs�ŕۑ����邽�߂̃L�[
	//private string highScoreKey = "highScore";
	// PlayerPrefs�ŕۑ����邽�߂̃L�[
	private string ScoreKey = "Score";
	void Start()
	{
		Initialize();

		// �n�C�X�R�A���擾����B�ۑ�����ĂȂ����0�_�B
		string name = FindObjectOfType<UserAuth>().currentPlayer();
		highScore = new NCMB.HighScore(0, name);
		highScore.fetch();
	}

	private void Initialize()
	{
		// �X�R�A��0�ɖ߂�
		score = 0;
		// �t���O������������
		isNewRecord = false;
	}

	void Update()
	{
		if(Input.GetMouseButton(0))
        {
			score += 100;
        }
		// �X�R�A���n�C�X�R�A���傫�����
		if (highScore.score < score)
		{
			isNewRecord = true; // �t���O�𗧂Ă�
			highScore.score = score;
		}

		// �X�R�A�E�n�C�X�R�A��\������
		scoreGUIText.text = score.ToString();
        highScoreGUIText.text = "HighScore : " + highScore.score.ToString();

		if(Input.GetMouseButton(1))
        {
			FindObjectOfType<Score>().Save();
		}
	}

	// �|�C���g�̒ǉ�
	public void AddPoint(int point)
	{
		score = score + point;
	}

	// �n�C�X�R�A�̕ۑ�
	public void Save()
	{
		// �n�C�X�R�A��ۑ�����i�������L�^�̍X�V���������Ƃ������j
		if (isNewRecord)
			highScore.save();

		// �Q�[���J�n�O�̏�Ԃɖ߂�
		// Initialize();
	}

	public void SceneChange()
    {
		SceneManager.LoadScene("LogOut");
    }
}