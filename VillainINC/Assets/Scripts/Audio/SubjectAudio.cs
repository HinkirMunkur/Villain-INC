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

    public void PushAudio() 
    {
        StartCoroutine(PushAudioCoroutine());
    }

    private IEnumerator PushAudioCoroutine() 
    {
        while (_subjectBasic.SubjectStateMachineController.GetCurrentState() == ESubjectState.PUSH) 
        {
            AudioManager.Instance.PlaySoundEffect("Pushing");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
