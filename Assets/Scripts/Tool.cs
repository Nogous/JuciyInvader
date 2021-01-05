using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool
{
    public static IEnumerator FadeImage(bool fadeAway, SpriteRenderer sprite, float fadeSpeed = 1f)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime* fadeSpeed)
            {
                // set color with i as alpha
                sprite.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime* fadeSpeed)
            {
                // set color with i as alpha
                sprite.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
