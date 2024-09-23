using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score;
    public static ScoreManager inst;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI countdown; //timer
    float _startTime = 3f;
    
    
    public void Awake()
    {
        gameOverScreen.SetActive(false);
        inst = this;
    }
    void Start()
    {
        StartCoroutine(StartCountdown());
    }
    public IEnumerator StartCountdown()
    {
        float _currentTime = _startTime;
        while (_currentTime >0)
        {
            _currentTime -=Time.deltaTime;
            countdown.text = Mathf.Ceil(_currentTime).ToString("0");
            yield return null;
        }
        countdown.text = "Go!";
        
        if(playerController != null)
        {
            playerController.startRunning();
        }
         yield return new WaitForSeconds(0.3f); //wait for the next frame
            countdown.text = "";
       
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();

        playerController.Speed += playerController.speedIncreasePoint;    
    }

    void Update()
    {
        if(!playerController.alive)
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void RestartButtonClicked()
    {
        
        StartCoroutine(RestartAfterDelay(2));     
    }  
    IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RestartUI();
    }

    public void RestartUI()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
    
}
