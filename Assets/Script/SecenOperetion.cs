using UnityEngine;

public class SecenOperetion : MonoBehaviour
{
    [SerializeField] GameObject opretPanel; //��������p�l��
    
    void Start()
    {
        opretPanel.SetActive(false);//�ŏ��͕\���Ȃ�
    }


    public void ChangeToOperationOn()
    {
        opretPanel.SetActive(true);//�\��
    }

    public void ChangeToOperationOff()
    {
        opretPanel.SetActive(false);//��\��
    }
}
