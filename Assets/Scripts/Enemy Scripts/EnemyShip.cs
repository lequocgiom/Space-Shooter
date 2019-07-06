using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bullet;

    public float speedX, speedY, bounds;
    private bool moveLeft;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shooting());
        StartCoroutine(RandomStart());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Bounds();
    }

    void Movement()
    {
        Vector3 temp = transform.position;
        temp.y -= speedY * Time.deltaTime;
        transform.position = temp;

        if (moveLeft)
        {
            Vector3 moveLeft = transform.position;
            moveLeft.x -= speedX * Time.deltaTime;
            transform.position = moveLeft;

        }

        else
        {
            Vector3 moveLeft = transform.position;
            moveLeft.x += speedX * Time.deltaTime;
            transform.position = moveLeft;
        }
    }

    void Bounds()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y);
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        StartCoroutine(Shooting());
    }

    IEnumerator RandomStart()
    {
        yield return new WaitForSeconds(0);
        if (transform.position.x > 0)
            moveLeft = true;
        else
            moveLeft = false;
    }
}
