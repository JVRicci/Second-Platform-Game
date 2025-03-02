using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;


// using System.Numerics;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed;

    public float jump_force;
    public bool can_jump;
    public bool double_jump;

    private Rigidbody2D rig;
    private BoxCollider2D box_col;
    private Animator anim;
    

    private bool is_blowing = false;
    // Lista de objetos / inimigos que causam dano ao personagem
    private String[] enemies = {"Spike", "Saw"};

    // Start is called before the first frame update
    void Start()
    {
        // Nas seguintes linhas são atribuidos os objetos dentro das variáveis criadas anteriormente
        //possibilitando a manipulação dos mesmos.
        rig = GetComponent<Rigidbody2D>();
        box_col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_Movement();
        Jump();
    }

    void Player_Movement(){

        // Criando movimentação para o player

        // Verifica qual eixo do teclado está sendo pressionado
        float movement = Input.GetAxis("Horizontal");

        //Atribui velocidade ao player com base na física do rigdbody
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        // Faz com que a animação mude ao andar e tbm se inverta dependendo do lado
        if (movement != 0f){
            anim.SetBool("walking", true) ;
            if (movement > 0f){
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if (movement < 0f){
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        } else if (movement == 0f) {
            anim.SetBool("walking", false);
        }

    }

    void Jump(){

        bool jump = Input.GetButtonDown("Jump");
        // Implementa pulo no player
        if(jump){
            // Verifica se pode pular e se não está flutuando
            if (can_jump && !is_blowing ){
                // Ativa a animação de pulo do player, 
                // O nome entre aspas é da variavel criada dentro do animator, a qual é um bool
                anim.SetBool("jumping", true);
                // AddForce faz com o que o player seja impulsionado para alguma dipreção
                // Vector2 faz o calculo entre eixo x e y
                rig.AddForce(new Vector2(0f, jump_force), ForceMode2D.Impulse);
                double_jump = true;
            } else if (jump && double_jump) {
                rig.AddForce(new Vector2(0f,(jump_force - 2)), ForceMode2D.Impulse);
                double_jump = false;
            }
        }        
    }   
    
    private void OnCollisionEnter2D(Collision2D other) {
        // Verifica se o player está em contato com o chão
        if (other.gameObject.layer == 8){
            // Desativa a animação de pulo assim que toca no chão
            anim.SetBool("jumping", false);
            // Ativa a possibilida de pulo e pulo duplo
            can_jump = true;
            double_jump = true;
        }

        if (enemies.Contains(other.gameObject.tag)){
            Destroy(gameObject);
            GameController.instance.ShowGameOver();
        }

        if (other.gameObject.tag == "NextStageCheckpoint"){
            GameController.instance.NextStage();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        // Verifica se o player perdeu contato com chão
        if(other.gameObject.layer == 8){
            can_jump = false;
        // Permite pular duas vezes
        } 
    }

    // Verifica enquanto está colidindo com um objeto de trigger ativo
    void OnTriggerStay2D(Collider2D other)
    {
        // Enquanto estiver flutuando, desativa o double jump
        if(other.gameObject.tag == "Fan") 
            is_blowing = true;
            double_jump = false;
    }

    // Verifica se saiu da colisão com object trigger
    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se parou de flutuar com o ventilador
        if (other.gameObject.tag == "Fan" )
            is_blowing = false;
    }
}
