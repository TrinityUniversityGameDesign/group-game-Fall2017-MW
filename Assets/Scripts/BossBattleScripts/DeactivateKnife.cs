using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateKnife : MonoBehaviour {

    void start() {
        OnEnable();
    }
    void OnEnable()
    {
        Invoke("Destroy", 4.0f);
    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
        CancelInvoke();
    }
}
