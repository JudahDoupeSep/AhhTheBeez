using System.Collections;
using UnityEngine;

public class ShakeRandomly : MonoBehaviour
{
    public float ShakeTime = 2;
    
    void Start()
    {
        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(ShakeTime, ShakeTime * 3));
            
            var remainingSeconds = ShakeTime;
            var t = 0f;
            while (t < 1)
            {
                yield return new WaitForEndOfFrame();

                transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 180, easeInOutBounce(t)));
                remainingSeconds -= Time.deltaTime;
                t = 1 - (remainingSeconds / ShakeTime);
            }
            
            yield return new WaitForSeconds(Random.Range(ShakeTime, ShakeTime * 3));
            
            remainingSeconds = ShakeTime;
            t = 0f;
            while (t < 1)
            {
                yield return new WaitForEndOfFrame();

                transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(180, 360, easeInOutBounce(t)));
                remainingSeconds -= Time.deltaTime;
                t = 1 - (remainingSeconds / ShakeTime);
            }
        }
        
        float easeInOutBounce(float t)
        {
            return t < 0.5
                ? (1 - easeOutBounce(1 - 2 * t)) / 2
                : (1 + easeOutBounce(2 * t - 1)) / 2;
        }
        
        float easeOutBounce(float t) {
            float n1 = 7.5625f;
            float d1 = 2.75f;

            if (t < 1 / d1) {
                return n1 * t * t;
            } else if (t < 2 / d1) {
                return n1 * (t -= 1.5f / d1) * t + 0.75f;
            } else if (t < 2.5 / d1) {
                return n1 * (t -= 2.25f / d1) * t + 0.9375f;
            } else {
                return n1 * (t -= 2.625f / d1) * t + 0.984375f;
            }
        }
    }
}
