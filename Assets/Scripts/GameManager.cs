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

    // 游戏结束菜单
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text gameOverBestScoreText;

    // 计分菜单
    [SerializeField] private GameObject scoreMenu;
 

    public void AddScore() {
        Score++;
        scroeText.text = Score.ToString();
    }

    public void SetGameOver() {
        IsGameOver = true;

        // 隐藏计分菜单
        scoreMenu.SetActive(false);

        // 显示结束菜单
        gameOverMenu.SetActive(true);

        // PlayerPrefs相当于一个内存数据Key-Value缓存
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
