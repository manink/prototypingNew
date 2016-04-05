using UnityEngine;
using System.Collections;

public class AudioManager : Singleton<AudioManager> {

    class ClipInfo {
        //ClipInfo used to maintain default audio source info
        public AudioSource source { get; set; }
        public float defaultVolume { get; set; }
    }

    private ArrayList m_activeAudio = new ArrayList();

    public AudioSource Play(AudioClip clip, Vector3 soundOrigin, float volume)
    {
        //Create an empty game object
        GameObject soundLoc = new GameObject("Audio: " + clip.name);
        soundLoc.transform.position = soundOrigin;

        //Create the source
        AudioSource source = soundLoc.AddComponent<AudioSource>();
        setSource(ref source, clip, volume);
        source.Play();
        Destroy(soundLoc, clip.length);

        //Set the source as active
        m_activeAudio.Add(new ClipInfo { source = source, defaultVolume = volume });
        return source;
    }

    public AudioSource PlayLoop(AudioClip loop, Transform emitter, float volume)
    {
        //Create an empty game object
        GameObject movingSoundLoc = new GameObject("Audio: " + loop.name);
        movingSoundLoc.transform.position = emitter.position;
        movingSoundLoc.transform.parent = emitter;
        //Create the source
        AudioSource source = movingSoundLoc.AddComponent<AudioSource>();
        setSource(ref source, loop, volume);
        source.loop = true;
        source.Play();
        //Set the source as active
        m_activeAudio.Add(new ClipInfo { source = source, defaultVolume = volume });
        return source;
    }

    //public void stopSound(AudioSource toStop)
    //{
    //    try
    //    {
    //        Destroy(m_activeAudio.Find(s => s.source == toStop).source.gameObject);
    //    }
    //    catch
    //    {
    //        Debug.Log("Error trying to stop audio source " + toStop);
    //    }
    //}

    private void setSource(ref AudioSource source, AudioClip clip, float volume)
    {
        source.rolloffMode = AudioRolloffMode.Logarithmic;
        source.dopplerLevel = 0.2f;
        source.minDistance = 150;
        source.maxDistance = 1500;
        source.clip = clip;
        source.volume = volume;
    }

    public AudioSource Play(AudioClip clip, Transform emitter, float volume)
    {
        var source = Play(clip, emitter.position, volume);
        source.transform.parent = emitter;
        return source;
    }

    void Awake()
    {
        Debug.Log("AudioManager Initializing");
        try
        {
            transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
            //transform.localPosition = new Vector3(0, 0, 0);
        }
        catch
        {
            Debug.Log("Unable to find main camera to put audiomanager");
        }
    }
}
