using UnityEngine;
using System.Linq;
using System.Collections.Generic;
public class EnemyController : MonoBehaviour
{
    
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float TiempoEnemigos;
    
    
    private float TiempoSiguente;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        TiempoSiguente +=Time.deltaTime;
        if(TiempoSiguente >= TiempoEnemigos)
        {
            TiempoSiguente = 0;
            CrearEnemigo();
        }
    }
    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
        
    }

    
    
}
