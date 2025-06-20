using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    public AudioClip Yiyang_Negro;
    public AudioSource source;
    public int points;
    public GameObject projectilePrefab;
    public float shootInterval;
    public float shootTimer;
    public Transform shootPoint;
    public float fixedY;
    int stars = 0;
    private const float MIN_X = -2.7f;
    private const float MAX_X = 2.7f; 
    private void Awake()
    {
        fixedY = -4;
        source = GetComponent<AudioSource>(); 
    }
    void Shoot()
    { 

        
        if(Input.GetMouseButton(0)  && shootTimer <= 0)
        {
            shootTimer = 0.3f;
            Instantiate(projectilePrefab, transform.position , projectilePrefab.transform.rotation);
            source.Play();


        }
    }

    public TextMeshProUGUI abel_gay;
    
    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
        {
            Move(Input.mousePosition);
        }

        if (Input.touchCount > 0)
        {
            Move(Input.GetTouch(0).position);
        }

        


        shootTimer -= Time.deltaTime;
        Shoot();

    }
    void Move(Vector2 position)
    {
       
        

            Vector2 realPos = Camera.main.ScreenToWorldPoint(position);

       
            if (realPos.x > MIN_X && realPos.x < MAX_X && Mathf.Abs(realPos.x - transform.position.x ) > 0.2f)
            {
                StopAllCoroutines();
                StartCoroutine(MoveGradually(realPos));
            }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        
        if (collision.tag == "Star")
        {
            stars++;
            abel_gay.text = "ESTRELLAS " + stars.ToString();
            Destroy(collision.gameObject);
            source.PlayOneShot(Yiyang_Negro);
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
