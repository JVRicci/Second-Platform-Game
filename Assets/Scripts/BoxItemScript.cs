using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItemScript : MonoBehaviour
{

    [SerializeField]
    private float box_impulse;
    [SerializeField]
    private bool is_up;
    //É necessário selecionar o item pai pela interface da unity
    // com a animação para fazer com que o ative a animação 
    public Animator anim;
    public int health;
    public int apples;

    void Update()
    {
        BoxDestroyed();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            // Verifica se o player atingiu a caixa por baixo ou por cima
            // Ele irá aplica impulso dependendo do lado que atingir
            box_impulse = is_up ?  -box_impulse : box_impulse;
            anim.SetTrigger("hit");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, box_impulse), ForceMode2D.Impulse);
            health--;
        }
    }

    void BoxDestroyed (){
        if (health <= 0){
            // Adciona uma quantidade de maçãs ao score
            GameController.instance.total_score += apples;
            GameController.instance.UpdateScoreText();
            // Faz com que o objeto pai seja destruido
            Destroy(transform.parent.gameObject);
        }
    }
}
    
