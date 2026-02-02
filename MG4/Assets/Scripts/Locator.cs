using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class Locator : MonoBehaviour {
    public static Locator Instance { get; private set; }
    public Player Player { get; private set; }
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
            Debug.Log("1");
            return;
    }
        Instance = this;
        GameObject playerObj = GameObject.FindWithTag("Player");
        Player = playerObj.GetComponent<Player>();
    }
}