using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragmentation : MonoBehaviour
{
    public GameObject smallAsteroidPrefab; 
    public int fragmentsCount = 3; 
    public float fragmentSpread = 1f; 
    public float fragmentForce = 3f; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Fragment(); 
            Destroy(gameObject); 
        }
    }

    void Fragment()
    {
        for (int i = 0; i < fragmentsCount; i++)
        {
        
            Vector3 randomOffset = Random.insideUnitSphere * fragmentSpread;
            Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, 0, randomOffset.z); // 控制Z方向，确保碎片水平分布

            
            GameObject fragment = Instantiate(smallAsteroidPrefab, spawnPosition, Quaternion.identity);

            Rigidbody rb = fragment.GetComponent<Rigidbody>();
            if (rb != null)
            {
               
                Vector3 downwardForce = new Vector3(0, -fragmentForce, 0);
                rb.AddForce(downwardForce, ForceMode.Impulse);

              
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}

