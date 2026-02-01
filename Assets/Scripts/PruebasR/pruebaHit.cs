using UnityEngine;

public class pruebaHit : MonoBehaviour
{
    public void OnHit()
    {
        Debug.Log("Entro al hit");
        GetComponent<BoxCollider2D>().enabled = false;
        gameObject.SetActive(false);
    }

}
