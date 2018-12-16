using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Takes care of the transitions between scenes.
 * Is not destroyed on load, also holds the eventmanager in the gameobject
 * Transitions fade screen
 * Also audio fade in and out */
public class TransitionManager : MonoBehaviour {

    public static TransitionManager transMan;

    private void Awake()
    {
        if(transMan == null)
        {
            DontDestroyOnLoad(gameObject);
            transMan = this;
            EventManager.StartListening(0, TransitionIn);
            EventManager.StartListening(1, TransitionOut);
        }
        else if(transMan != this)
        {
            Destroy(gameObject);
        }
    }

    public UnityEngine.UI.Image fadeScreen;
    public AudioSource backgroundSource;

    public float fadeTime;

    public void TransitionIn ()
    {
        fadeScreen.CrossFadeAlpha(0f, fadeTime, false);
        StartCoroutine(FadeIn(backgroundSource, fadeTime));
    }

    public void TransitionOut ()
    {
        fadeScreen.CrossFadeAlpha(1f, fadeTime, false);
        StartCoroutine(FadeOut(backgroundSource, fadeTime));
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1)
        {
            audioSource.volume += ((1 * Time.deltaTime) / FadeTime);
            yield return null;
        }

        audioSource.volume = 1;
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}