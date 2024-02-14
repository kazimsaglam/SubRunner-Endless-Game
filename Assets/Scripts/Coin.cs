using UnityEngine;

public class Coin : MonoBehaviour
{
    private InteractionManager IM;
    private Transform player;

    private float distance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        IM = player.GetComponent<InteractionManager>();
    }

    private void Update()
    {
        if (IM.isMagnet)
        {
            distance = Vector3.Distance(transform.position, player.position);

            if(distance <= 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * 10f);
            }
        }
    }

    private void OnBecameInvisible()
    {
        ObjectPooler.Instance.ReturnToPool(gameObject);
    }
}
