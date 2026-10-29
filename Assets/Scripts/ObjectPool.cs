using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolsize;

    private List<GameObject> objectPoolList = new List<GameObject>();
    void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolsize; i++)
        {
            CreateNewObject();
        }
    }
    /// <summary>
    /// Instantiate new object
    /// </summary>
    /// <returns></returns>
    private GameObject CreateNewObject()
    {
        GameObject newObject = Instantiate(objectPrefab);

        newObject.SetActive(false);

        objectPoolList.Add(newObject);
        return newObject;
    }

     public GameObject GetObjectFromPool()
    {
        // Find an inactive object in the pool list
        GameObject theObject = objectPoolList.Find(obj => !obj.activeInHierarchy);

        if (theObject == null)
        {
            theObject = CreateNewObject();
        }

        theObject.SetActive(true);
        return theObject;
    }
}
