using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public AudioClip coinSound;
    public bool isMagnet = false;

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position, 0.3f);
            gameManager.IncreaseScore(50);
            ObjectPooler.Instance.ReturnToPool(other.gameObject);
        }

        if (other.CompareTag("Magnet"))
        {
            // Ayný anda birden fazla mýknatýs alamasýn diye var olan mýknatýslarý siliyoruz.
            GameObject[] allMagnests = GameObject.FindGameObjectsWithTag("Magnet");

            foreach (GameObject m in allMagnests)
            {
                ObjectPooler.Instance.ReturnToPool(m);
            }

            isMagnet = true;
            Invoke("ResetMagnet", 10f);
        }
    }

    private void ResetMagnet()
    {
        isMagnet = false;
    }

}
