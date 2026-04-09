using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioSource ThemeSource;
    [SerializeField] private AudioClip[] sfxs;
    [SerializeField] Slider sfxSlider;

    public static AudioManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
        
        ThemeSource = GetComponent<AudioSource>();
        
        sfxSlider.maxValue = 2;
        sfxSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void VolumSet()
    {
        float volume = sfxSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        ThemeSource.volume = volume;
        
        print(volume);
    }
    public void PlaySfx(int sfxNum)
    {
        if (sfxs[sfxNum] == null)
            return;

        ThemeSource.PlayOneShot(sfxs[sfxNum]);
    }
}
