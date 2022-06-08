using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class FadeAudioSource
{
    //este script es solo este ienumerator que hace el fade. lo llamo desde audiomanager
    //por diego katabian

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float initialVolume, float desiredVolume)
    {
        float timer = 0;
        float start = initialVolume;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, desiredVolume, timer / duration);
            yield return null;
        }
        yield break;
    }
}