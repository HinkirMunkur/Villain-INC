using UnityEngine;
using Munkur;

public class AudioSceneBegin : MonoBehaviour
{
    [SerializeField] private string _musicToBePlayed;
    private void Start() 
    {
        if (!AudioManager.Instance.IsMusicPlaying) 
        {
            AudioManager.Instance.PlayMusic(_musicToBePlayed);
        }
    }
}
