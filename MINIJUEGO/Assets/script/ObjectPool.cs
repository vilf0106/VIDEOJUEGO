using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // 子弹预制体
    public int poolSize = 10; // 初始池大小
    private List<GameObject> pool;

    void Start()
    {
        // 初始化对象池
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false); // 初始时不激活
            pool.Add(obj);
        }
    }

    // 从池中获取对象
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

        // 如果池中没有可用对象，则创建新的对象并加入池中
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

    // 将对象归还到池中
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
