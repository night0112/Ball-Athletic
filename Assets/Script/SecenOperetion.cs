using UnityEngine;

public class SecenOperetion : MonoBehaviour
{
    [SerializeField] GameObject opretPanel; //操作説明パネル
    
    void Start()
    {
        opretPanel.SetActive(false);//最初は表示なし
    }


    public void ChangeToOperationOn()
    {
        opretPanel.SetActive(true);//表示
    }

    public void ChangeToOperationOff()
    {
        opretPanel.SetActive(false);//非表示
    }
}
