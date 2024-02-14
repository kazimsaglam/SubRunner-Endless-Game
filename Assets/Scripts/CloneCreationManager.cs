using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCreationManager : MonoBehaviour
{
    public Transform player;

    private float xPos = 2;
    private float zPos = 40;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnTrap());
        StartCoroutine(SpawnMagnet());
        StartCoroutine(SpawnTrain());
        StartCoroutine(SpawnMovingTrain());
    }

    IEnumerator SpawnCoin()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            int i = Random.Range(0, 3);
            GameObject coin = ObjectPooler.Instance.GetFromPoolCoin();
            if(i == 0)
            {
                coin.transform.position = new Vector3(0, 1f, player.position.z + zPos);
            }
            else if(i == 1)
            {
                coin.transform.position = new Vector3(xPos, 1f, player.position.z + zPos);
            }
            else
            {
                coin.transform.position = new Vector3(-xPos, 1f, player.position.z + zPos);
            }
            
            coin.SetActive(true);
        }
    }

    IEnumerator SpawnTrap()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            int i = Random.Range(0, 3);
            GameObject trap = ObjectPooler.Instance.GetFromPoolTrap();
            if (i == 0)
            {
                trap.transform.position = new Vector3(0, 0, player.position.z + zPos);
            }
            else if (i == 1)
            {
                trap.transform.position = new Vector3(xPos, 0, player.position.z + zPos);
            }
            else
            {
                trap.transform.position = new Vector3(-xPos, 0, player.position.z + zPos);
            }

            trap.SetActive(true);
        }
    }

    IEnumerator SpawnMagnet()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            int i = Random.Range(0, 3);
            GameObject magnet = ObjectPooler.Instance.GetFromPoolMagnet();
            if (i == 0)
            {
                magnet.transform.position = new Vector3(0, 1f, player.position.z + zPos);
            }
            else if (i == 1)
            {
                magnet.transform.position = new Vector3(xPos, 1f, player.position.z + zPos);
            }
            else
            {
                magnet.transform.position = new Vector3(-xPos, 1f, player.position.z + zPos);
            }

            magnet.SetActive(true);
        }
    }

    IEnumerator SpawnTrain()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            int i = Random.Range(0, 3);
            GameObject train = ObjectPooler.Instance.GetFromPoolTrain();
            if (i == 0)
            {
                train.transform.position = new Vector3(0, 0, player.position.z + zPos);
            }
            else if (i == 1)
            {
                train.transform.position = new Vector3(xPos, 0, player.position.z + zPos);
            }
            else
            {
                train.transform.position = new Vector3(-xPos, 0, player.position.z + zPos);
            }

            train.SetActive(true);
        }
    }

    IEnumerator SpawnMovingTrain()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            int i = Random.Range(0, 3);
            GameObject movingTrain = ObjectPooler.Instance.GetFromPoolMovingTrain();
            if (i == 0)
            {
                movingTrain.transform.position = new Vector3(0, 0, player.position.z + zPos);
            }
            else if (i == 1)
            {
                movingTrain.transform.position = new Vector3(xPos, 0, player.position.z + zPos);
            }
            else
            {
                movingTrain.transform.position = new Vector3(-xPos, 0, player.position.z + zPos);
            }

            movingTrain.SetActive(true);
        }
    }
}
