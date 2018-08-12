using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    private AudioSource musicPlayer;
    private AudioClip musicLoop;

    private List<AudioClip> songs = new List<AudioClip>();
    private List<AudioClip> sounds = new List<AudioClip>();

    private int currentTrack = 0;

    public static string[] Sounds = {
            "boost"
            , "burning"
            , "chargeup"
            , "exp_small1"
            , "exp_small2"
            , "exp_small3"
            , "exp_small4"
            , "exp1"
            , "exp2"
            , "exp3"
            , "impact1"
            , "impact2"
            , "impact3"
        };

    public static string[] Songs = { "chargeup" };

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        musicPlayer = GetComponent<AudioSource>();
        
        foreach (string song in Songs)
        {
            songs.Add((Resources.Load<AudioClip>(song)));
        }
        
        foreach (string sound in Sounds)
        {
            sounds.Add(Resources.Load<AudioClip>(sound) as AudioClip);
        }

        //LoopSong(0);
        DontDestroyOnLoad(gameObject);
    }

    private bool shouldCharge = true;
    public IEnumerator PlayChargingSound(int sound = 2)
    {
        AudioSource effect = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        effect.clip = sounds[Mod(sound, sounds.Count)];
        effect.loop = true;
        effect.pitch = 0.1f;
        effect.volume = 0.2f;
        effect.Play();

        while (shouldCharge)
        {
            if (effect.pitch < 1.2f)
            {
                effect.pitch += Time.deltaTime * 0.5f;
                effect.volume += Time.deltaTime * 0.5f;
            }
            yield return new WaitForEndOfFrame();
        }
        shouldCharge = true;
        effect.Stop();
        Destroy(effect);
        PlaySound(0);
    }
    public void StopCharging()
    {
        shouldCharge = false;
    }

    public void PlaySound(int sound)
    {
        AudioSource effect = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        effect.clip = sounds[Mod(sound, sounds.Count)];
        effect.Play();
        Destroy(effect, effect.clip.length + 0.2f);
    }

    public void PlayRandomize(float pitch, params int[] sound)
    {
        AudioSource effect = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        int random = Random.Range(0, sound.Length);
        effect.clip = sounds[Mod(sound[Mod(random, sound.Length)], sounds.Count)];
        effect.pitch = Random.Range(1 - pitch, 1 + pitch);
        effect.Play();
        Destroy(effect, effect.clip.length);
    }

    public void LoopSong(int number)
    {
        currentTrack = number;
        musicPlayer.loop = true;
        musicPlayer.clip = songs[number];
        musicPlayer.Play();
    }

    private int Mod(int x, int m)
    {
        return ((x % m) + m) % m;
    }
}