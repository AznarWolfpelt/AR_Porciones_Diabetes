using UnityEngine;

public class LookForward : MonoBehaviour
{
    // Dirección fija en la que el objeto mirará
    public Vector3 forwardDirection = Vector3.forward;

    void Update()
    {
        // Normaliza la dirección para evitar escalado
        if (forwardDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
        }
    }
}
