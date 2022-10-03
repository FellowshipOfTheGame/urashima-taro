using UnityEngine.Audio;
using UnityEngine;

// Mark the Sound class as serializable enabling a variable list of Sound (used in the AudioManager.cs)
[System.Serializable]
public class EnemySound: Sound
{
    public float spatialBlend = 1f;
}