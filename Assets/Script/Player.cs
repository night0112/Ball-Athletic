using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveForce = 10.0f;//移動力
    [SerializeField] public float jumpForce = 5.0f;//ジャンプ力
    private Rigidbody rb;

    [SerializeField] public float respawnHeight = -5f;//リスポーン処理の起動条件
    private Vector3 startPosition; //初期位置

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //初期位置保存
        startPosition = transform.position;
    }

    void Update()
    {
        //キー移動
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");


        //移動ベクトル
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 force = (forward * moveZ + right * moveX) * moveForce;
        rb.AddForce(force);


        //地面にいるときジャンプ
        if(Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }

        //リスポーン判定
        if(transform.position.y < respawnHeight)
        {
            Respawn();
        }

        //リスポーン（進行不能になった場合用）
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    private bool IsGrounded()
    {
        float radius = GetComponent<SphereCollider>().radius;
        float distance = 1.05f;
        float coe = 0.9f;
        //地面判定
        return Physics.SphereCast(transform.position, radius * coe, Vector3.down, out _, distance);
    }

    //リスポーン処理
    private void Respawn()
    { 
        rb.linearVelocity = Vector3.zero;      
        rb.angularVelocity = Vector3.zero; 
        transform.position = startPosition; 
    }
}
