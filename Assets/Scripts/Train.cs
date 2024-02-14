using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public bool isMoving = false;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.parent.gameObject.transform.Translate(Vector3.back * 5f * Time.deltaTime);
        }
    }

    private void OnBecameInvisible()
    {
        ObjectPooler.Instance.ReturnToPool(transform.parent.gameObject);
    }
}
