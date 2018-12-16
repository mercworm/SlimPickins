using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Players")]
public class Data_Players : ScriptableObject
{
    public string characterName;

    public float speed;
    public float peckSpeed;
    public float pushForce;

    public GameObject playerPrefab;
}
