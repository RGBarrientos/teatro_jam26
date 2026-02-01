using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.linearVelocity = new Vector2(moveDir.x,moveDir.y);
        Destroy(this.gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MageController>().takeDamage(20);
            gameObject.SetActive(false);
            Debug.Log("colisiono");
        }
        if (collision.gameObject.tag == "pared")
        {
            gameObject.SetActive(false);
            Debug.Log("colisiono piso");
        }
    }
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    
}
