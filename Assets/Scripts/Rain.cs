using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rain : MonoBehaviour
{

    private ParticleSystem _ps;
    private bool isRain = false;
    public Light dirLight;

    void Awake()
    {
        _ps = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    void Update()
    {
        if (isRain && dirLight.intensity > 0.4f)
            LightIntensity(-1);
        else if(!isRain && dirLight.intensity < 0.8f)
            LightIntensity(1);
    }

    private void LightIntensity(int mult)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * mult;
    }

    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(30f, 50f));
            if(!isRain)
                _ps.Play();
            else 
                _ps.Stop();

            isRain = !isRain;
        }
    }


}
