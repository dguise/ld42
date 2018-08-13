using Assets.Scripts.Helper.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class SpacebarController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float chargePower;
    public float turnSpeed;
    public float dischargeMaxTime;
    [Range(1, 10)] public int startingFuel = 3;

    private float dischargeTime;
    private float spaceStartTime;
    private float chargeUpTime = 2f;
    private float chargeFactor;
    private bool charging = false;

    private float chargeTrailTimestamp;

    private float discStartScale = 0.3f;
    private float discEndScale = 1.4f;

    private Transform engineDisc1;
    private ParticleSystem ps1;
    private Transform engineDisc2;
    private ParticleSystem ps2;

    private ParticleSystem ecp1;
    private ParticleSystem ecp2;

    public int FuelCanisters { get; internal set; }
    public delegate void FuelCanisterPickup();
    public event FuelCanisterPickup OnFuelPickup;
    public delegate void FuelCanisterUse();
    public event FuelCanisterPickup OnFuelUse;

    public delegate void GainScore();
    public event GainScore OnGainScore;

    private ParticleSystem psDeath;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        engineDisc1 = transform.Find("EngineDisc1");
        ps1 = transform.Find("EngineParticles1").GetComponent<ParticleSystem>();
        engineDisc2 = transform.Find("EngineDisc2");
        ps2 = transform.Find("EngineParticles2").GetComponent<ParticleSystem>();

        ecp1 = transform.Find("EngineChargeParticles1").GetComponent<ParticleSystem>();
        ecp2 = transform.Find("EngineChargeParticles2").GetComponent<ParticleSystem>();

        psDeath = GetComponent<ParticleSystem>();
        psDeath.Stop();

        GainFuel(startingFuel);
    }

    void Boost(float power)
    {
        rb.AddForce(-transform.up * power);
        ecp1.gameObject.SetActive(true);
        ecp2.gameObject.SetActive(true);
        ecp1.Play();
        ecp2.Play();
        DisableStuff();
        chargeTrailTimestamp = Time.time;
        dischargeTime = dischargeMaxTime * chargeFactor;
    }

    void Update()
    {
        //transform.LookAt(CrossPlatformInputManager.mousePosition); //Funkar men blir för 3d, lul
        //if mobile ?
        if (SystemInfo.deviceType == DeviceType.Handheld && (Input.GetMouseButton(0)))
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();
            diff *= -1;
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }

        //Input.GetKeyDown(KeyCode.Space
        if (KeyDown() && FuelCanisters > 0)
        {
            spaceStartTime = Time.time;
            charging = true;
            FuelCanisters--;
            if (AudioManager.instance != null)
                StartCoroutine(AudioManager.instance.PlayChargingSound());
            if (OnFuelUse != null)
                OnFuelUse();
        }
        //Input.GetKeyUp(KeyCode.Space
        else if (KeyUp() && charging)
        {
            if (AudioManager.instance != null)
                AudioManager.instance.StopCharging();
            charging = false;
            Boost(chargePower * chargeFactor);
        }
        //Input.GetKey(KeyCode.Space
        else if (Key() && charging)
        {
            if (!engineDisc1.gameObject.activeSelf)
                EnableStuff();
            ChargeUp();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            float t = turnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + Mathf.LerpAngle(0, 5, t));
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            float t = turnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + Mathf.LerpAngle(0, -5, t));
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1 - Time.timeScale;
        }

        if (Time.time - chargeTrailTimestamp > dischargeTime) {
            ecp1.Stop();
            ecp2.Stop();
        }
    }
    bool KeyDown()
    {
        return (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
    }
    bool KeyUp()
    {
        return (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0));
    }
    bool Key()
    {
        return (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0));
    }

    void ChargeUp()
    {
        chargeFactor = Mathf.Min((Time.time - spaceStartTime) / chargeUpTime, 1f);
        float scale = discStartScale + (discEndScale - discStartScale) * chargeFactor;
        engineDisc1.transform.localScale = new Vector3(scale, scale, scale);
        engineDisc2.transform.localScale = new Vector3(scale, scale, scale);
        
        Camera.main.GetComponent<CameraShake>().Shake(chargeFactor, chargeFactor);
    }

    void DisableStuff()
    {
        engineDisc1.gameObject.SetActive(false);
        engineDisc2.gameObject.SetActive(false);
        ps1.gameObject.SetActive(false);
        ps2.gameObject.SetActive(false);
        ps1.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        ps2.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    void EnableStuff()
    {
        engineDisc1.gameObject.SetActive(true);
        engineDisc2.gameObject.SetActive(true);
        ps1.gameObject.SetActive(true);
        ps2.gameObject.SetActive(true);
        ps1.Play();
        ps2.Play();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == Tags.Fuel)
        {
            GainFuel(3);
            AudioManager.instance.PlaySound(14);
            Destroy(collider.gameObject);
        }
        else if (collider.tag == Tags.SuperFuel)
        {
            GainFuel(3);
            StartCoroutine(SuperBoost());
            AudioManager.instance.PlaySound(15);
            Destroy(collider.gameObject);
        }
        else if (collider.tag == Tags.Astroboi)
        {
            AudioManager.instance.PlaySound(13);
            if (OnGainScore != null)
                OnGainScore();

            Destroy(collider.gameObject);
        }
        else if (collider.tag == "WinOnTouch")
        {
            Fader.Instance.FadeOut(() =>
            {
                SceneManager.LoadScene("5_WinScreen");
            });
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlayRandomize(0, 10, 11, 12);

        if (collision.gameObject.tag == "Planet") {
            psDeath.Play();
            Destroy(ecp1);
            Destroy(ecp2);
            enabled = false;
        }
    }

    private IEnumerator SuperBoost()
    {
        var start = 0f;

        while (start < 3f)
        {
            Boost(10);
            start += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
    }

    public void GainFuel(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            FuelCanisters++;
            if (OnFuelPickup != null)
                OnFuelPickup();
        }
    }
}
