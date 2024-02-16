using UnityEngine;

public class RollingRock : MonoBehaviour
{
    private void Update()
    {
        transform.parent.gameObject.transform.Translate(Vector3.back * 5f * Time.deltaTime);
        transform.Rotate(35f, 0f, 0f);
    }

    private void OnBecameInvisible()
    {
        ObjectPooler.Instance.ReturnToPool(transform.parent.gameObject);
    }
}
