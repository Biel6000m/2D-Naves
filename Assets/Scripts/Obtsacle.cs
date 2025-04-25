using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obtsacle : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
        Destroy(collision.gameObject);
            StartCoroutine(DestroyRoutine());
        }

        if(collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
           
        }
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
