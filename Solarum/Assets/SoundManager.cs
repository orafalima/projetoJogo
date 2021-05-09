using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip selectSound, changeSound, starSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        selectSound = Resources.Load<AudioClip>("Audio/select");
        changeSound = Resources.Load<AudioClip>("Audio/change");
        starSound = Resources.Load<AudioClip>("Audio/star");

        audioSource = GetComponent<AudioSource>();
    }

    public static void Play(string clip)
    {
        switch (clip)
        {
            case "change":
                audioSource.PlayOneShot(changeSound);
                break;
            case "select":
                audioSource.PlayOneShot(selectSound);
                break;
            case "star":
                audioSource.PlayOneShot(starSound);
                break;
        }
    }
}
