using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        ObjectPooler.Instance.ReturnToPool(gameObject);
    }
}
