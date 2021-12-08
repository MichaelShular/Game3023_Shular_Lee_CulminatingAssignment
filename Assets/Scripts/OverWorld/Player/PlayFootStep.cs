using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootStep : MonoBehaviour
{
    private AudioSource source;
    public List<AudioClip> sounds;
    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playFootStep() { 
        source.clip = sounds[0];
        source.Play();
    }
}
