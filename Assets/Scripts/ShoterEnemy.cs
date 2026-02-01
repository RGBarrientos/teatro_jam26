using System.Collections.Generic;
using UnityEngine;

public class ShoterEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    private Transform player;
    public float shootingRange;
    public GameObject BulletEnemy;
    public GameObject BulletParent;
    public float FireRate = 1f;
    private float nextFireTime;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player =GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime);
        }
        else if(distanceFromPlayer <= shootingRange && nextFireTime<Time.time)
        {
            
            
            Instantiate(BulletEnemy, BulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + FireRate;
        }
        
        
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    
}
