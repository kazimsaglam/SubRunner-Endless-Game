using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        ObjectPooler.Instance.ReturnToPool(gameObject);
    }
}
