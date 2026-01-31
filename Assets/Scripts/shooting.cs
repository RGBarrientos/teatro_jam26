using UnityEngine;

public class shooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().linearVelocity = firePoint.right * bulletSpeed;
        }
    }
}
