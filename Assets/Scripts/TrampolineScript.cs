using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public float jump_force;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            anim.SetTrigger("jump");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump_force), ForceMode2D.Impulse);
        }
    }
}
