using UnityEngine;

public class Delivery : MonoBehaviour
{

    private bool _hasPackage = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !_hasPackage)
        {
            _hasPackage = true;
            Destroy(other.gameObject, 0.5f);
            GetComponent<ParticleSystem>().Play();
        }

        if (other.CompareTag("Customer") && _hasPackage)
        {
            Debug.Log("Customer");
            _hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
