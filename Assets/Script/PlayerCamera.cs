using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Transform player;//�Ǐ]�Ώ�
    [SerializeField] public Vector3 offset = new Vector3(0, 5, -8);//�J�����ʒu�̃I�t�Z�b�g
    [SerializeField] public float speed = 5.0f;//�Ǐ]���x
   
    void LateUpdate()
    {
        //�v���C���[�����Ȃ��Ƃ��͂��Ȃ�
        if (player == null)
        {
            return;
        }


        Vector3 desiredPosition = player.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;

        //��Ƀv���C���[������
        transform.LookAt(player);
    }
}
