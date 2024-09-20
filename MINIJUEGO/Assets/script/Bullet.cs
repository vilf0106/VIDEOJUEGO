using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    private ObjectPool pool; // 引用对象池

    // Start is called before the first frame update
    void Start()
    {
        pool = FindObjectOfType<ObjectPool>(); // 查找对象池
        Invoke("ReturnToPool", maxLifeTime); // 定时回收到对象池
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
            Destroy(collision.gameObject); // 销毁敌人
            ReturnToPool(); // 不销毁子弹，而是回收到对象池
        }
    }

    // 回收子弹到对象池
    private void ReturnToPool()
    {
        pool.ReturnToPool(gameObject); // 归还到对象池
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
