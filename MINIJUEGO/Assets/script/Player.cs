using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 100f;
    public float rotationSpeed = 120f;
    private Rigidbody _rigid;
    public static int SCORE = 0;
    private float xBorderLimit;
    private float yBorderLimit;

    public GameObject gun;
    public ObjectPool bulletPool; 

    void Start()
    {
        Camera cam = Camera.main;
        xBorderLimit = cam.orthographicSize * cam.aspect;
        yBorderLimit = cam.orthographicSize;
        _rigid = GetComponent<Rigidbody>();
        _rigid.drag = 2f;
        _rigid.angularDrag = 2f;
    }

    void Update()
    {
        Vector3 newPos = transform.position;

       
        if (newPos.x > xBorderLimit)
        {
            newPos.x = -xBorderLimit;
        }
        else if (newPos.x < -xBorderLimit)
        {
            newPos.x = xBorderLimit;
        }

        if (newPos.y > yBorderLimit)
        {
            newPos.y = -yBorderLimit;
        }
        else if (newPos.y < -yBorderLimit)
        {
            newPos.y = yBorderLimit;
        }

        transform.position = newPos;

        
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;
        float rotation = Input.GetAxis("Rotate") + Time.deltaTime;
        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);
        transform.Rotate(Vector3.forward, -rotation * rotationSpeed * Time.deltaTime);

       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject bullet = bulletPool.GetFromPool();
            bullet.transform.position = gun.transform.position;
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("He colisionado con otra cosa...");
        }
    }
}
