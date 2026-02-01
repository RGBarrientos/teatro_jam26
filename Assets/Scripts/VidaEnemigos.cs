using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    [SerializeField] private float vida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
            {
                gameObject.SetActive(false);
            }
    }
    public void takeDamage(float damage)
    {
        vida -= damage;
        
    }
}
