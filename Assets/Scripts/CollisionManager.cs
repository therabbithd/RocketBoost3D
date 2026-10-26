using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    [Header("Audio Settings")]
    [SerializeField] private AudioClip explosionAudioClip;
    [SerializeField] private AudioClip landingAudioClip;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem explosionParticleSystem;
    [SerializeField] private ParticleSystem landingParticleSystem;

    AudioSource audioSource;

    bool isControllable = true;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isControllable) return;

        switch (collision.gameObject.tag)
        {
            case "LaunchPad":
                Debug.Log("LaunchPad Collision Detected");
                break;
            case "LandingPad":
                ManageCollision(landingAudioClip, landingParticleSystem);
                break;
            case "Explosion":
                ManageCollision(explosionAudioClip, explosionParticleSystem);
                break;
            default:                
                break;
        }
    }

    /// <summary>
    /// Manages the collision event by disabling player control, 
    /// stopping any ongoing audio, playing the specified audio clip, 
    /// playing the specified particle system, 
    /// and disabling the PlayerMovement script.
    /// </summary>
    /// <param name="audioClip"></param>
    private void ManageCollision(AudioClip audioClip, ParticleSystem particleSystem)
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
        particleSystem.Play();
        GetComponent<PlayerMovement>().enabled = false;        
    }
    

    
}
