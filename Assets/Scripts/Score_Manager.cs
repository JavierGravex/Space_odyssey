using UnityEngine;
using TMPro;

public class Score_Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float _score = 0f;
    [SerializeField] private float _pointsPerSecond = 20f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _score = 0;

    }
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + _score.ToString("F0");
        
    }

    // Update is called once per frame
    void Update()
    {
        _score += _pointsPerSecond * Time.deltaTime;
        UpdateScoreText();
    }




}
