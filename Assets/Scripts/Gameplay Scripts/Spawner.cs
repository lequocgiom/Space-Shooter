using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemies;

    private float timer = 0.5f, xBound = 2.3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int randomEnemy = Random.Range(0, enemies.Length);

        Instantiate(enemies[randomEnemy], new Vector2(Random.Range(-xBound, xBound),
            transform.position.y), transform.rotation);

        yield return new WaitForSeconds(timer);
        StartCoroutine(Spawn());
    }
}
