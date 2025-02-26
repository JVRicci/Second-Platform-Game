using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FallingPlatformScript : MonoBehaviour
{
    public float falling_time;

    private TargetJoint2D target; 
    private BoxCollider2D box_collider;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        box_collider = GetComponent<BoxCollider2D>();
    }

    // Verifica se o player colidiu com a plataforma, caso sim, a plataforma cai
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            // O comando invoke serve para executar um comando após um certo tempo
            Invoke("Falling", falling_time);
        }
    }
    // Como a plataforma no momento que cair já estará com o trigger ativo,
    // é necessário utilizar esse metodo para checar a colisão 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6){
            Destroy(gameObject);
        }
    }
    // Metodo chamado quando o player entrar em contato com a plataforma
    public void Falling(){
        // Desativa o targetJoint
        target.enabled = false;
        //Ativa o trigger do box_collider
        box_collider.isTrigger = true;
    }
}
