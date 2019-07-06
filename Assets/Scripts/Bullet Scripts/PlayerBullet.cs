using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float speed = 8f;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "enemy")
        {
            int randomScore = Random.Range(100, 300);

            gameController.AddScore(randomScore);

            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}
