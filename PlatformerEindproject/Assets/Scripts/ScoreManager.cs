using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreCount += pointsPerSecond * Time.deltaTime;

        scoreText.text = "Score: " + scoreCount;
        highScoreText.text = "High Score: " + highScoreCount;
    }
}
