using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    [SerializeField]
    private float speed;    
    [SerializeField]
    private float move_time; 
    private bool dir;
    private float timer;

    private CircleCollider2D col;
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    } 

    void Movement(){
        if(dir){
            // Faz com que a serra se movimente para a direita, e no else, faz com que vá para esquerda
            transform.Translate(Vector2.right * speed * timer);
        }
        else{
            transform.Translate(Vector2.right * speed * timer);
        }

        timer += Time.deltaTime;
        // Faz com que com o fim do contador, a direção seja trocada e reinicie o contador
        if(timer >= move_time){
            dir = !dir;
            timer = 0f;
        }
    }

    void OllisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(other.gameObject);
        }
    }
}
