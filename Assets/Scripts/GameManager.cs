using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int Score;
    public bool IsGameOver;
    [SerializeField] private TMP_Text scroeText;

    // ��Ϸ�����˵�
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text gameOverBestScoreText;

    // �Ʒֲ˵�
    [SerializeField] private GameObject scoreMenu;
 

    public void AddScore() {
        Score++;
        scroeText.text = Score.ToString();
    }

    public void SetGameOver() {
        IsGameOver = true;

        // ���ؼƷֲ˵�
        scoreMenu.SetActive(false);

        // ��ʾ�����˵�
        gameOverMenu.SetActive(true);

        // PlayerPrefs�൱��һ���ڴ�����Key-Value����
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (Score > bestScore) {
            bestScore = Score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        gameOverScoreText.text = "Score: " + Score.ToString();
        gameOverBestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    public void Retry() {
        SceneManager.LoadScene("GamePlay");
    }

    public void Exit() {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
