using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPersonaje : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    SpriteRenderer playerRenderer;

    Rigidbody2D rigi;

    [SerializeField] float jump = 6.0f;


    //Para el ataque
    [SerializeField] GameObject hitAtaque;
    float duracionAtaque = 0.15f;
    float sizeAtaque = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        rigi = GetComponent<Rigidbody2D>();
        hitAtaque.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
        SwitchHitbox();
    }

    void ControlPlayer(){
        if(Input.GetKey("d")){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            playerRenderer.flipX = false;
            Giro(1f);
        }
        if(Input.GetKey("a")){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            playerRenderer.flipX = true;
            Giro(-1f);
        }
        if(Input.GetKey("w") && Mathf.Abs(rigi.linearVelocity.y) < 0.01f){
            rigi.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown("j")){
            Ataque();
        }
    }

    void Giro(float direccion)
    {
        Vector3 currentPosition = hitAtaque.GetComponent<Transform>().localPosition;
        currentPosition.x = sizeAtaque * direccion;
        hitAtaque.GetComponent<Transform>().localPosition = currentPosition;
    }

    void SwitchHitbox(){
        if(Input.GetKeyDown("e")){
            BoxCollider2D boxAtaque = hitAtaque.GetComponent<BoxCollider2D>();
            if(sizeAtaque == 0.3f)
            {
                sizeAtaque = 0.15f;
                Vector2 size = boxAtaque.size;
                size.x = sizeAtaque;
                boxAtaque.size = size;
                Giro(1);
            }
            else
            {
                sizeAtaque = 0.3f;
                Vector2 size = boxAtaque.size;
                size.x = sizeAtaque;
                boxAtaque.size = size;
                Giro(1);
            }
        }
    }

    void Ataque()
    {
        StartCoroutine(CorrutinaAtaque());
    }

    IEnumerator CorrutinaAtaque()
    {
        hitAtaque.SetActive(true);
        yield return new WaitForSeconds(duracionAtaque);
        hitAtaque.SetActive(false);
    }
}
