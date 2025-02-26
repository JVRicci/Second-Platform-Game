using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AppleScript : MonoBehaviour
{
    private Animator anim;
    public int score ;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // É necessário ativar a opção "Is Trigger" dentro do circle collider da maçã
    // Vai servir para que quando o player colida com a maçã, ela seja destruida e coletada
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            anim.SetBool("collected", true);

            // Chama o GameController que a gente cria na interface da Unity, executando os método estático intance
            // Por meio desse método, é possivel acessar variáveis e funções do script GameController, criado por nós
            GameController.instance.total_score += score;
            GameController.instance.UpdateScoreText();

            // Destroi a maçã após 0.3 segundos
            Destroy(gameObject, .3f);
        }
        
    }
}
