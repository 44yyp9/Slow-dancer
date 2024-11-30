using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public static class CoroutineSenderHelper
{
    /// <summary>
    /// Sender‚ªãè‚­”­‰Î‚µ‚È‚©‚Á‚½‚½‚ß‹¤’Ê‰»‚µ‚½‚µ‚½ˆ—
    /// </summary>
    public static IEnumerator waitSbuscribe(Func<bool> condition,Action subscribe)
    {
        while (!condition())
        {
            yield return null;
        }
        subscribe?.Invoke();
    }
}
