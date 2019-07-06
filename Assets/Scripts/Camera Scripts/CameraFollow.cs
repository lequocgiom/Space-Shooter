using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeInHierarchy)
            transform.position = new Vector3(transform.position.x, player.transform.position.y +
                offset, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y +
                .5f, transform.position.z);
    }
}
