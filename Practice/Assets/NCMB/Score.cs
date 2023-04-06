using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	// スコアを表示するGUIText
	public UnityEngine.UI.Text scoreGUIText;

	// ハイスコアを表示するGUIText
	public Text highScoreGUIText;

	// ハイスコアを表示するGUIText
	public UnityEngine.UI.Text saveScoreGUIText = null;

	// スコア
	private int score;

	private NCMB.HighScore highScore;
	private bool isNewRecord;

	// ハイスコア
	//private int highScore;

	// PlayerPrefsで保存するためのキー
	//private string highScoreKey = "highScore";
	// PlayerPrefsで保存するためのキー
	private string ScoreKey = "Score";
	void Start()
	{
		Initialize();

		// ハイスコアを取得する。保存されてなければ0点。
		string name = FindObjectOfType<UserAuth>().currentPlayer();
		highScore = new NCMB.HighScore(0, name);
		highScore.fetch();
	}

	private void Initialize()
	{
		// スコアを0に戻す
		score = 0;
		// フラグを初期化する
		isNewRecord = false;
	}

	void Update()
	{
		if(Input.GetMouseButton(0))
        {
			score += 100;
        }
		// スコアがハイスコアより大きければ
		if (highScore.score < score)
		{
			isNewRecord = true; // フラグを立てる
			highScore.score = score;
		}

		// スコア・ハイスコアを表示する
		scoreGUIText.text = score.ToString();
        highScoreGUIText.text = "HighScore : " + highScore.score.ToString();

		if(Input.GetMouseButton(1))
        {
			FindObjectOfType<Score>().Save();
		}
	}

	// ポイントの追加
	public void AddPoint(int point)
	{
		score = score + point;
	}

	// ハイスコアの保存
	public void Save()
	{
		// ハイスコアを保存する（ただし記録の更新があったときだけ）
		if (isNewRecord)
			highScore.save();

		// ゲーム開始前の状態に戻す
		// Initialize();
	}

	public void SceneChange()
    {
		SceneManager.LoadScene("LogOut");
    }
}