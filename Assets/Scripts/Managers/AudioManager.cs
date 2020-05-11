using System;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public Sounds[] sounds;
        public static AudioManager Instance;

        private string _currentSceneName;
    
        // Start is called before the first frame update
        private void Awake()
        {
        
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        
            DontDestroyOnLoad(gameObject);
        
            foreach (Sounds s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
            
            Play("ScifiThemeMusic");
        }

        public void Play (string name)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + "not found!" );
                return;
            }
            s.source.Play();
        }
    
        public void Stop (string name)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + "not found!" );
                return;
            }
            s.source.Stop();
        }
    }
}
