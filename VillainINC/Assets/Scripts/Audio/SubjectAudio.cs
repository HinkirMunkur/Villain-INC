using System.Collections;
using UnityEngine;
using Munkur;

public class SubjectAudio : MonoBehaviour
{
    [SerializeField] private SubjectBasic _subjectBasic;
    public void RunAudio() 
    {
        StartCoroutine(RunAudioCoroutine());
    }

    private IEnumerator RunAudioCoroutine() 
    {
        while (_subjectBasic.SubjectStateMachineController.GetCurrentState() == ESubjectState.RUN) 
        {
            AudioManager.Instance.PlaySoundEffect("Running");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
