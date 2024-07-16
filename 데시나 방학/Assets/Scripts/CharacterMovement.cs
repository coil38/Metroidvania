using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400.0f;                            //���� �� �߰��Ǵ� ���� ��
    [Range(0, 0.3f)][SerializeField] private float m_MovementSmoothing = 0.05f;     //�̵��� �θ����� �ϱ����� ��źȭ
    [SerializeField] private bool m_AirControl = false;                             //���� �߿��� ���� �� �� �ִ��� ����
    [SerializeField] private LayerMask m_WhatlsGround;                              //ĳ���Ϳ��� ���� �������� �ạ�ϴ� ����ũ
    [SerializeField] private Transform m_GroundCheck;                               //�÷��̾ ���� ��Ҵ��� Ȯ���ϴ� ��ġ
    [SerializeField] private Transform m_WallChesk;                                 //�÷��̾ ���� ��Ҵ��� Ȯ���ϴ� ��ġ

    const float k_GroundedRadius = 0.2f;                            //���� ��Ҵ��� Ȯ���ϴ� ��ħ ���� �ݰ�
    private bool m_IsGrounded;                                      //�÷��̾ ���� ��Ҵ��� ����
    private Rigidbody2D m_Rigidbody2D;                              
    private bool m_facingRight = true;                              //�÷��̾ ���� ��� ������ �ٶ󺸰� �ִ� �� ����
    private Vector3 velocity = Vector3.zero;                        //�ӵ�
    private float limitFallSpeed = 25f;                             //���� �ӵ� ����

    public bool canDoubleJump = true;                               //�÷��̾ ���� ������ �� �� �ִ��� ����
    private bool m_IsWall = false;                                  //�÷��̾� �տ� ���� �ִ��� ����
    private bool m_IsWallSlidding = false;                          //�÷��̾ ���� Ÿ�� �ִ��� ����
    private bool oldWallSlidding = false;                           //���� �����ӿ��� �÷��̾ ���� Ÿ�� �־����� ����
    private float prevVelocityX = 0f;               
    private bool canCheck = false;                                  //�÷��̾ ���� Ÿ�� �ִ��� Ȯ���ϱ� ���� ����

    private Animator animator;

    private float jumpWallStartX = 0;
    private float jumpWallDistX = 0;                    //�÷��̾�� �� ������ �Ÿ�
    private bool limitVelOnWallJump = false;            //���� FPS���� �� ���� �Ÿ��� �����ϱ� ���� ����


}
