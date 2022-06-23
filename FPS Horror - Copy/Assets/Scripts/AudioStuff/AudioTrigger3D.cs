using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger3D : AudioTriggers
{
    public Vector3 soundPosition;

    public override void TriggerAndDestroy()
    {
        sound.transform.position = soundPosition;
        AudioManager.instance.TriggerSound(sound, fadeDuration, initialVolume, finalVolume, isPlay);
        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(soundPosition, 1);
    }
}
