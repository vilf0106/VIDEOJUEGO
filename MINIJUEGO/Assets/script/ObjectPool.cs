using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; 
    public int poolSize = 10; 
    private List<GameObject> pool;

    void Start()
    {
        
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false); 
            pool.Add(obj);
        }
    }

  
    public GameObject GetFromPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

     
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

 
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
