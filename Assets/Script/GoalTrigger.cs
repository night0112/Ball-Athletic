using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] float delayTime = 3.0f;//�f�B���C����
    private bool triggerd = false;

    [SerializeField] ParticleSystem goalParticle1;
    [SerializeField] ParticleSystem goalParticle2;
  
    private void OnTriggerEnter(Collider other)
    {
        if(triggerd)
        {
            return;
        }

        //�S�[��������̏���
        if (other.CompareTag("Player"))
        {
            Instantiate(goalParticle1,transform.position,Quaternion.identity);
            Instantiate(goalParticle2,transform.position,Quaternion.identity);
            triggerd = true;
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    private System.Collections.IEnumerator ChangeSceneAfterDelay()
    { 
        yield return new WaitForSeconds(delayTime); //�҂�

        SceneManager.LoadScene("TitleScene"); //�^�C�g����
    }
}
