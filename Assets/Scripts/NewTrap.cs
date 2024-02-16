using UnityEngine;

public class NewTrap : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        ObjectPooler.Instance.ReturnToPool(transform.parent.gameObject);
    }
}
