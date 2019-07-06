using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5, xBounds = 2.5f;

    public Transform bulletPos;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float hor = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float ver = speed * Time.deltaTime * .5f;

        transform.Translate(new Vector2(hor, ver));

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBounds, xBounds),
            transform.position.y);
    }

    IEnumerator Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "enemy" || target.tag == "enemyBullet")
        {
            Destroy(target.gameObject);
            gameObject.SetActive(false);
        }
    }
}
