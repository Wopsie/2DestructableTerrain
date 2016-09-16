using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField]
    private Text scoreText;

    private int score = 0;

    private GameObject[] targets;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");

        foreach(GameObject target in targets)
        {
            Debug.Log(target);
        }
    }

    public void IncrementScore()
    {
        score += 10;
        scoreText.text = "Score : " + score;
    }
}
