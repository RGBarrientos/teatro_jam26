using UnityEngine;

public class Bala : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pared")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.GetComponent<VidaEnemigos>().takeDamage(20);
            gameObject.SetActive(false);
            
        }
    }
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
}
