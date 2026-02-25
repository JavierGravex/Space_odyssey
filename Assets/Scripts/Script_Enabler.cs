using UnityEngine;
using System.Collections;

public class Script_Enabler : MonoBehaviour
{

    public WinCondition winConditionScript;

    public float timePassed = 180f; // The delay it takes to ebable a script

    void Start()
    {
        StartCoroutine(EnableScriptAfterDelay());
    }

    IEnumerator EnableScriptAfterDelay()
    {
        yield return new WaitForSeconds(timePassed);

        if( winConditionScript != null)
        {
            winConditionScript.enabled = true;
            Debug.Log("WinCondition script enabled after delay.");
        }

    }
}
