using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spaw : MonoBehaviour
{

    public float spawnInterval;
    public GameObject asteroid;
    public Transform BorderLeft;
    public Transform BorderRight;
    public float spawnTimer;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       spawnTimer -= Time.deltaTime;
    if(spawnTimer <= 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {

        float randomX = Random.Range(BorderLeft.position.x, BorderRight.position.x);

        Vector2 newPosition = transform.position;
        newPosition.x = randomX;

        Instantiate(asteroid, newPosition, Quaternion.identity);
        spawnTimer = spawnInterval;
    }
    
}
