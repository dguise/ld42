using Assets.Scripts.Helper;
using Assets.Scripts.Helper.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlameController : MonoBehaviour
{
    public GameObject flame;
    public float offset;
    public Vector3 flameScaleFactor;

    private Quaternion rot = Quaternion.Euler(0, 90, 0);

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == Tags.Fuel || col.transform.tag == Tags.SuperFuel)
        {
            AudioManager.instance.PlayRandomize(0, 3, 4, 5, 6);
        }
        else if (col.transform.GetComponent<Planet>() != null)
        {
            AudioManager.instance.PlayRandomize(0, 7, 8, 9);
        }
        Vector3 v = col.collider.transform.position;
        Vector3 scl = col.collider.transform.localScale;
        v.x -= offset * scl.x;

        GameObject obj = Instantiate(flame, v, rot);
        scl.x *= flameScaleFactor.x;
        scl.y *= flameScaleFactor.y;
        scl.z *= flameScaleFactor.z;
        obj.transform.Find("PS").localScale = scl;

        if (col.transform.tag == Tags.Player)
        {
            GameManager.PlayerHasFailedLetsGetRidOfHimMethod();
        }
        else
        {
            Destroy(obj, 2f * scl.y);
            Destroy(col.gameObject, 2f * scl.y);
        }
    }
}
