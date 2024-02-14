using System;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public GameObject[] roadSections;
    public int roadSize = 20;

    public List<GameObject> createdRoads;
    public List<GameObject> pooledRoads;

    public Transform roadParentContainer;

    private void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < roadSize; i++)
        {
            int index = UnityEngine.Random.Range(0, roadSections.Length);
            GameObject road = Instantiate(roadSections[index]);
            road.SetActive(false);
            road.transform.SetParent(roadParentContainer);
            pooledRoads.Add(road);
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject road = GetFromPool();

            road.transform.position = new Vector3(0f, 0f, createdRoads[createdRoads.Count - 1].transform.position.z + road.transform.Find("Rail").GetComponent<Renderer>().bounds.size.z);
            createdRoads.Add(road);
            road.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SectionTrigger"))
        {
            GameObject road = GetFromPool();

            road.transform.position = new Vector3(0f, 0f, createdRoads[createdRoads.Count - 1].transform.position.z + road.transform.Find("Rail").GetComponent<Renderer>().bounds.size.z);
            createdRoads.Add(road);
            road.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SectionTrigger"))
        {
            ObjectPooler.Instance.ReturnToPool(other.transform.parent.gameObject);
        }
    }

    private GameObject GetFromPool()
    {
        for (int i = 0; i < pooledRoads.Count; i++)
        {
            if (!pooledRoads[i].activeInHierarchy)
            {
                return pooledRoads[i];
            }
        }

        // Pool'dan mevcut nesne yoksa yeni bir tane oluþturabilirsiniz.
        int index = UnityEngine.Random.Range(0, roadSections.Length);
        GameObject newRoad = Instantiate(pooledRoads[index]);
        pooledRoads.Add(newRoad);
        newRoad.transform.SetParent(roadParentContainer);
        return newRoad;
    }
}
