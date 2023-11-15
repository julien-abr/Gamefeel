using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text textScore;

    // Start is called before the first frame update
    void UpdateScore(int score)
    {
        textScore.text = score.ToString();
    }

}
