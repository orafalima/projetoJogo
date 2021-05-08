using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip selectSound, changeSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        selectSound = Resources.Load<AudioClip>("Audio/select");
        changeSound = Resources.Load<AudioClip>("Audio/change");

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
        }
    }
}
