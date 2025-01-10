using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShake : MonoBehaviour
{
    private void Update()
    {
        // Verifica si la tecla Espacio es presionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        }
    }

}
