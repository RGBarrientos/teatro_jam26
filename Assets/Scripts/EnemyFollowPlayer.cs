using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player =GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime);
    }
}
