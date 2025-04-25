using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int points;
    public GameObject projectilePrefab;
    public float shootInterval;
    public float shootTimer;
    public Transform shootPoint;
    public float fixedY;

    private const float MIN_X = -2.7f;
    private const float MAX_X = 2.7f; 
    private void Awake()
    {
        fixedY = -4;
    }
    void Shoot()
    {
        if(Input.GetMouseButton(0)  && shootTimer <= 0)
        {
            shootTimer = 0.3f;
            Instantiate(projectilePrefab, transform.position , projectilePrefab.transform.rotation);
            
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        Move();
        shootTimer -= Time.deltaTime;
        Shoot();

    }
    void Move()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);

       
            if (realPos.x > MIN_X && realPos.x < MAX_X && Mathf.Abs(realPos.x - transform.position.x ) > 0.2f)
            {
                StopAllCoroutines();
                StartCoroutine(MoveGradually(realPos));
            }
        
        }
    }


    private IEnumerator MoveGradually(Vector2 _target_position)
    {
        float Distance = Mathf.Abs(transform.position.x - _target_position.x);
        if ((transform.position.x > _target_position.x))
        {
            while (transform.position.x > _target_position.x)
            {
                transform.position = new Vector2(transform.position.x - 0.15f, transform.position.y);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        else
        {
            while (transform.position.x < _target_position.x)
            {
                transform.position = new Vector2(transform.position.x + 0.15f, transform.position.y);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        transform.position = new Vector2(_target_position.x, fixedY);

    }
}
