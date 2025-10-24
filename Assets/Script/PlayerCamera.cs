using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Transform player;//追従対象
    [SerializeField] public Vector3 offset = new Vector3(0, 5, -8);//カメラ位置のオフセット
    [SerializeField] public float speed = 5.0f;//追従速度
   
    void LateUpdate()
    {
        //プレイヤーがいないときはやらない
        if (player == null)
        {
            return;
        }


        Vector3 desiredPosition = player.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;

        //常にプレイヤーを見る
        transform.LookAt(player);
    }
}
