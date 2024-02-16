using UnityEngine;

public class Train : MonoBehaviour
{
    public bool isMoving = false;

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
