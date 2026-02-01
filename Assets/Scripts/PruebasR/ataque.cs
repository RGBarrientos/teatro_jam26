using UnityEngine;

public class ataque : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destructible"))
        {
            other.GetComponent<pruebaHit>()?.OnHit();
        }
    }
}
