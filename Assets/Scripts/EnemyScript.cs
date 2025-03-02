using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    [SerializeField] 
    private float speed;

    // Faz com que o inimigo detecte a colisão de um dos lados quando um dos dois estiver ativo
    public Transform right_collision;
    public Transform left_collision;

    // Verifica a colisão quando o personagem cair na cabeça
    public Transform head_collision;

    private bool colliding;

    private BoxCollider2D box_col;
    private CircleCollider2D circle_col;

    public LayerMask layer;
    private bool player_destroyed;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box_col = GetComponent<BoxCollider2D>();
        circle_col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Faz com que o inimigo se movimente
        //O velocity.y faz com que n tenha movimentação no eixo y
        rig.velocity = new Vector2(speed, rig.velocity.y);

        //Cria uma linha invisivel que detecta um raio de colisão 
        colliding = Physics2D.Linecast(right_collision.position, left_collision.position, layer);

        // QUando ocorrer a colisão, ele vai fazer com que o eixo x se inverta
        // O speed indica o eixo x
        if(colliding){
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y );
            speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if( other.gameObject.tag == "Player"){
            // Verifica se onde que o player colidiu, se foi por cima ou em outro angulo
            float height = other.contacts[0].point.y - head_collision.position.y;
            // Caso tenha sido por cima e o player ainda exista
            if( height > 0 && !player_destroyed){
                // Faz com que o player pule após caiu no inimigo
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                anim.SetTrigger("Death");
                box_col.enabled = false;
                circle_col.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, .2f);
            }
            else{
                //Ele marca como destruido o player
                player_destroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(other.gameObject);
            }
        }
    }
}
