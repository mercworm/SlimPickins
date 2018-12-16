using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Takes care of the transitions between scenes.
 * Is not destroyed on load, also holds the eventmanager in the gameobject
 * Transitions fade screen
 * Also audio fade in and out
 */
public class TransitionManager : MonoBehaviour {

    public static TransitionManager transMan;

    private void Awake()
    {
        if(transMan == null)
        {
            DontDestroyOnLoad(gameObject);
            transMan = this;
            EventManager.StartListening(0, TransitionIn);
            EventManager.StartListening(1, TransitionOut);
        }
        else if(transMan != this)
        {
            Destroy(gameObject);
        }
    }

    public void TransitionIn ()
    {

    }

    public void TransitionOut ()
    {

    }
}
