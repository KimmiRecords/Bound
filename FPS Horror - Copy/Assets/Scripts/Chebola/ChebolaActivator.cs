using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChebolaActivator : MonoBehaviour
{
    //este script es como chebolaspawner. pero le cargas chebolas en escena que esten desactivados, y los activa.
    //por dk

    public GameObject[] chebolasParaActivar;

    private void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded)
        {
            return;
        }

        for (int i = 0; i < chebolasParaActivar.Length; i++)
        {
            chebolasParaActivar[i].SetActive(true);
        }
    }
}
