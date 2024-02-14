using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    public GameObject coinPrefab;
    public int poolSizeCoin = 30;

    public GameObject[] trapPrefabs;
    public int poolSizeTrap = 12;

    public GameObject magnetPrefabs;
    public int poolSizeMagnet = 3;

    public GameObject[] trainPrefabs;
    public GameObject[] movingTrainPrefabs;
    public int poolSizeTrain = 15;

    public List<GameObject> pooledCoins = new List<GameObject>();
    public List<GameObject> pooledTraps = new List<GameObject>();
    public List<GameObject> pooledMagnets = new List<GameObject>();
    public List<GameObject> pooledTrains = new List<GameObject>();
    public List<GameObject> pooledMovingTrains = new List<GameObject>();

    public Transform coinParentContainer;
    public Transform trapParentContainer;
    public Transform trainParentContainer;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < poolSizeCoin; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);

            coin.transform.SetParent(coinParentContainer);

            pooledCoins.Add(coin);
        }

        for (int i = 0; i < poolSizeTrap; i++)
        {
            int index = Random.Range(0, trapPrefabs.Length);
            GameObject trap = Instantiate(trapPrefabs[index]);
            trap.SetActive(false);

            trap.transform.SetParent(trapParentContainer);

            pooledTraps.Add(trap);
        }

        for (int i = 0; i < poolSizeMagnet; i++)
        {
            GameObject magnet = Instantiate(magnetPrefabs);
            magnet.SetActive(false);

            pooledMagnets.Add(magnet);
        }

        for (int i = 0; i < poolSizeTrain; i++)
        {
            int index = Random.Range(0, trainPrefabs.Length);
            GameObject train = Instantiate(trainPrefabs[index]);
            train.SetActive(false);

            train.transform.SetParent(trainParentContainer);

            pooledTrains.Add(train);
        }

        for (int i = 0; i < poolSizeTrain; i++)
        {
            int index = Random.Range(0, movingTrainPrefabs.Length);
            GameObject movingTrain = Instantiate(movingTrainPrefabs[index]);
            movingTrain.SetActive(false);

            movingTrain.transform.SetParent(trainParentContainer);

            pooledMovingTrains.Add(movingTrain);
        }
    }

    public GameObject GetFromPoolCoin()
    {
        for (int i = 0; i < pooledCoins.Count; i++)
        {
            if (!pooledCoins[i].activeInHierarchy)
            {
                return pooledCoins[i];
            }
        }

        // Pool'dan mevcut nesne yoksa yeni bir tane oluþturabilirsiniz.
        GameObject newCoin = Instantiate(coinPrefab);
        pooledCoins.Add(newCoin);
        newCoin.transform.SetParent(coinParentContainer);
        return newCoin;
    }

    public GameObject GetFromPoolTrap()
    {
        for (int i = 0; i < pooledTraps.Count; i++)
        {
            if (!pooledTraps[i].activeInHierarchy)
            {
                return pooledTraps[i];
            }
        }

        // Pool'dan mevcut nesne yoksa yeni bir tane oluþturabilirsiniz.
        int index = Random.Range(0, trapPrefabs.Length);
        GameObject newTrap = Instantiate(trapPrefabs[index]);
        pooledTraps.Add(newTrap);
        newTrap.transform.SetParent(trapParentContainer);
        return newTrap;
    }

    public GameObject GetFromPoolMagnet()
    {
        for (int i = 0; i < pooledMagnets.Count; i++)
        {
            if (!pooledMagnets[i].activeInHierarchy)
            {
                return pooledMagnets[i];
            }
        }

        // Pool'dan mevcut nesne yoksa yeni bir tane oluþturabilirsiniz.
        GameObject newMagnet = Instantiate(magnetPrefabs);
        pooledMagnets.Add(newMagnet);
        return newMagnet;
    }

    public GameObject GetFromPoolTrain()
    {
        for (int i = 0; i < pooledTrains.Count; i++)
        {
            if (!pooledTrains[i].activeInHierarchy)
            {
                return pooledTrains[i];
            }
        }

        // Pool'dan mevcut nesne yoksa yeni bir tane oluþturabilirsiniz.
        int index = Random.Range(0, trainPrefabs.Length);
        GameObject newTrain = Instantiate(trainPrefabs[index]);
        pooledTrains.Add(newTrain);
        newTrain.transform.SetParent(trainParentContainer);
        return newTrain;
    }

    public GameObject GetFromPoolMovingTrain()
    {
        for (int i = 0; i < pooledMovingTrains.Count; i++)
        {
            if (!pooledMovingTrains[i].activeInHierarchy)
            {
                return pooledMovingTrains[i];
            }
        }

        // Pool'dan mevcut nesne yoksa yeni bir tane oluþturabilirsiniz.
        int index = Random.Range(0, movingTrainPrefabs.Length);
        GameObject newMovingTrain = Instantiate(movingTrainPrefabs[index]);
        pooledMovingTrains.Add(newMovingTrain);
        newMovingTrain.transform.SetParent(trainParentContainer);
        return newMovingTrain;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
