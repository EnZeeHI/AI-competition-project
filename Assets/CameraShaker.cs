using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    //This script is largely a Brackey's script, found here: https://www.youtube.com/watch?v=9A9yj8KnM8c
    private Vector3 originalPosition;

    void Start(){
        originalPosition = transform.localPosition;
    }

    public IEnumerator Shake(float duration, float severity)
    {
        float elapsed = 0.0f;
        float shaky;

        while(elapsed < duration)
        {
            shaky = 1 - elapsed / duration;
            float x = Random.Range(-shaky, shaky) * severity;
            float y = Random.Range(-shaky, shaky) * severity;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}