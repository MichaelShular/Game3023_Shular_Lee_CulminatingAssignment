using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public enum TrackID
{
    OverWorld,
    BattleMusic,
}
public class SoundManager : MonoBehaviour
{
    
    private SoundManager() { }

    private static SoundManager instance = null;

    public static SoundManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                DontDestroyOnLoad(instance.transform.root);
            }
            return instance;
        }
        private set { instance = value; }
    }

    [SerializeField] List<AudioClip> musicTracks;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixer mixer;
    public void PlayTrack(TrackID id)
    {
        audioSource.clip = musicTracks[(int)id];
        audioSource.Play();
        
    }

    void DestoryAllClones()
    {
        SoundManager[] clones = FindObjectsOfType<SoundManager>();
        foreach (SoundManager clone in clones)
        {
            if(clone!= Instance)
            {
                Destroy(clone.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DestoryAllClones();
        Instance.PlayTrack(TrackID.OverWorld);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setVolume(float volumeDB)
    {
        mixer.SetFloat("VolumeMusic", volumeDB);
    }
}
