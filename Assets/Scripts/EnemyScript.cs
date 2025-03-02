using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody rig;
    private Animator anim;

    [SerializeField] 
    private float speed;

    // Faz com que o inimigo detecte a colisão de um dos lados quando um dos dois estiver ativo
    public Transform right_collision;
    public Transform left_collision;

    // Verifica a colisão quando o personagem cair na cabeça
    public Transform head_collision;

    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Faz com que o inimigo se movimente
        //O velocity.y faz com que n tenha movimentação no eixo y
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(right_collision.position, left_collision.position);

        if(colliding){
            
        }
    }
}
