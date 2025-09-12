using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instances;
    public AudioMixer audioMixer;
    private void Awake()
    {
        if (Instances == null)
        {
            Instances = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
