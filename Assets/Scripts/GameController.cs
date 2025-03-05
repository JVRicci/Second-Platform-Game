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
    // Cria uma intancia do gameController para utilização de método estático
    void Start()
    {
        instance = this;
    }

    // Função chamada quando o player pega colide com a maçã e "coleta"
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

    //Carrega outra cena setada na interface da unity. 
    public void NextStage(){
        SceneManager.LoadScene(next_stage_name);
    }

    public void StartGame(){
        SceneManager.LoadScene("Phase_1");
    }
}
