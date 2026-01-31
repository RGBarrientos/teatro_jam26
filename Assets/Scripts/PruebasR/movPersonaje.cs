using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;

    SpriteRenderer playerRenderer;

    Rigidbody2D rigi;

    [SerializeField]
    float jump = 6.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void movePlayer(){
        if(Input.GetKey("d")){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            playerRenderer.flipX = false;
        }
        if(Input.GetKey("a")){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            playerRenderer.flipX = true;
        }
        if(Input.GetKey("w") && Mathf.Abs(rigi.linearVelocity.y) < 0.01f){
            rigi.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
}
