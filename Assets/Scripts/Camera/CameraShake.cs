using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Tooltip("Amount of shake")]
    public float shakeAmountX = 0.4f;
    public float shakeAmountY = 0.20f;
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

    public void Shake(float amountX = 0, float amountY = 0)
    {
        this.duration = shakeTime;
    }

    Vector3 GetOffset()
    {
        var xShake = Random.Range(-shakeAmountX, shakeAmountX);
        var yShake = Random.Range(-shakeAmountY, shakeAmountY);

        return new Vector3(xShake, yShake, 0);
    }
}