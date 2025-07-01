using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlowTime : MonoBehaviour
{
    public Button btn;
    
    private float originalFixedDeltaTime;
 

    void Start()
    {
        originalFixedDeltaTime = Time.fixedDeltaTime;
    }



    IEnumerator TimeSlow()
    {

        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;


        yield return new WaitForSecondsRealtime(3f);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = originalFixedDeltaTime;
        btn.gameObject.SetActive(false);

            
        
    }

    public void StartTimeSlow()
    {
        StartCoroutine(TimeSlow());
    }


}
