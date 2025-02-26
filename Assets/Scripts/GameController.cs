using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Lib para utilização de Text na UI
using TMPro;

public class GameController : MonoBehaviour
{
    public int total_score ;
    // Texto que foi criado na interface UI do jogo 
    public TMP_Text score_text ;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText(){
        score_text.text = total_score.ToString().PadLeft(4, '0');
    }
}
