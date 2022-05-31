using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    //este script se lo pones a una luz para que vaya y venga
    //lo uso para la luz roja de alarma en la secuencia final
    //por diego katabian

    public Light luz; //esta luz

    public float minIntensity;
    public float maxIntensity;
    public float frequency;

    float timer;
    float amplitude;

    void Start()
    {
        if (luz == null)
        {
            luz = GetComponent<Light>();
        }
        amplitude = maxIntensity - minIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        luz.intensity = Mathf.Sin(timer * frequency) * amplitude + (maxIntensity + minIntensity)/2;
    }
}
