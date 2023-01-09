using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Restaurant restaurant;
    private const int scoreNeeded = 10;
    private const float time = 25;
    private float startTime;
    void Start() => startTime = Time.time;

    // Update is called once per frame
    void Update()
    {
        var timeSince = time - (Time.time - startTime);
        Debug.Log(timeSince);
        timerText.text = $"Time Left: {Mathf.Floor(timeSince / 60)}:{Mathf.Floor(timeSince % 60).ToString("00")}";
        scoreText.text = $"Score: {restaurant.score}";
        if (timeSince <= 0) SceneManager.LoadScene(restaurant.score < scoreNeeded ? "FailedScene" : "SuccessScene");
    }
}