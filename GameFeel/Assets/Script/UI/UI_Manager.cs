using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameStatsRef gameStatsRef;
    [SerializeField] private TMP_Text textScore;

    private void Start()
    {
        gameStatsRef.OnScoreChanged += UpdateScore;
    }
    void UpdateScore(int score)
    {
        textScore.text = score.ToString();
    }

}
