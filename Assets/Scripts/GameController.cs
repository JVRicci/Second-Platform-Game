using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Lib para utilização de Text na UI
using TMPro;
// biblioteca responsável por conrolar fases do jogo
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int total_score ;
    public string next_stage_name;
    // Texto que foi criado na interface UI do jogo 
    public TMP_Text score_text ;
    public GameObject game_over;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText(){
        score_text.text = total_score.ToString().PadLeft(4, '0');
    }

    public void ShowGameOver(){
        game_over.SetActive(true);
    }

    public void RestartStage(string stage_name){
        // Função responsável por recarregar a fase, ou carregar alguma fase
        //O nome recebido via parametro é o nome da fase
        SceneManager.LoadScene(stage_name);
    }

    public void NextStage(){
        SceneManager.LoadScene(next_stage_name);
    }
}
