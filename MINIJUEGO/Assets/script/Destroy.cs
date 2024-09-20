using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBulletHit : MonoBehaviour
{
    // 引用对象池
    public ObjectPool objectPool;

    private void OnCollisionEnter(Collision collision)  // 使用 OnCollisionEnter 来检测碰撞
    {
        if (collision.gameObject.CompareTag("Bullet"))  // 确保检测子弹的标签
        {
            Debug.Log("Small fragment hit by bullet, returning to pool.");
            
            // 将小碎片返回到对象池，而不是销毁
            objectPool.ReturnToPool(gameObject);
        }
    }
}
