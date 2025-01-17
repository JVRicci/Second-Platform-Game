using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    private Animator anim;
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
            Destroy(gameObject, .3f);
        }
        
    }
}
