using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBulletHit : MonoBehaviour
{
    
    public ObjectPool objectPool;

    private void OnCollisionEnter(Collision collision)  
    {
        if (collision.gameObject.CompareTag("Bullet"))  
        {
            Debug.Log("Small fragment hit by bullet, returning to pool.");
            
          
            objectPool.ReturnToPool(gameObject);
        }
    }
}
