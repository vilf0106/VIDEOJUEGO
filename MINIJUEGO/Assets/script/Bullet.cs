using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    private ObjectPool pool; 

    // Start is called before the first frame update
    void Start()
    {
        pool = FindObjectOfType<ObjectPool>(); 
        Invoke("ReturnToPool", maxLifeTime); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();
            Destroy(collision.gameObject); 
            ReturnToPool(); 
        }
    }

    
    private void ReturnToPool()
    {
        pool.ReturnToPool(gameObject); 
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }
}
