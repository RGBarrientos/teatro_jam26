using System;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;
    private float anguloGrados;
    private List<GameObject> pool= new List<GameObject>();
    
    Vector2 lookDirection;
    Vector3 objetivo;
    [SerializeField] private Camera camara;
    float lookAngle;

    void Start()
    {
        //movi=FindAnyObjectByType<MovimientoP>();
    }
    
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(camara.transform.position.z);
        objetivo=camara.ScreenToWorldPoint(mousePos);

        
        Vector2 direccion = objetivo - transform.position;
        anguloGrados = (Mathf.Atan2(direccion.y,direccion.x) * Mathf.Rad2Deg) + 180f;
        
        transform.rotation = Quaternion.Euler(0,0,anguloGrados);
        //Debug.Log(anguloGrados);
        

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = getBala();
            bulletClone.transform.position=firePoint.position;
            bulletClone.transform.rotation=firePoint.rotation;
            //GameObject bulletClone = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            rb.linearVelocity = (firePoint.right *-1)* bulletSpeed;
        }
    }

    public GameObject getBala()
    {
        for(int i=0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = Instantiate(bullet) as GameObject;
        pool.Add(obj);
        return obj;
    }

    public float getGrados()
    {
        return anguloGrados;
    }
    
}
