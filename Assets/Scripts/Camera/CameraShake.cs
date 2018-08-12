using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Tooltip("Amount of shake")]
    public float maxShakeAmountX = 0.4f;
    public float maxShakeAmountY = 0.20f;
    private float realShakeAmountX;
    private float realSshakeAmountY;

    public float duration = 0;
    private float shakeTime = 0.8f;
    public bool shake = false;

    void LateUpdate()
    {
        if (duration > 0 || shake)
        {
            this.transform.position += GetOffset();
            duration -= Time.deltaTime;
        }
    }

    public void Shake(float amountX = 0, float amountY = 0) //Chargefactor som vi får in är 0-1
    {
        
        realShakeAmountX = (amountX / 1) * maxShakeAmountX;
        realSshakeAmountY = (amountY / 1) * maxShakeAmountY;

        this.duration = shakeTime;
    }

    Vector3 GetOffset()
    {
        var xShake = Random.Range(-realShakeAmountX, realShakeAmountX);
        var yShake = Random.Range(-realSshakeAmountY, realSshakeAmountY);

        return new Vector3(xShake, yShake, 0);
    }
}