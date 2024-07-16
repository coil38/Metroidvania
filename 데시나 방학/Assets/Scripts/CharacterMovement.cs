using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400.0f;                            //점프 시 추가되는 힘의 양
    [Range(0, 0.3f)][SerializeField] private float m_MovementSmoothing = 0.05f;     //이동을 부르럽게 하기위해 평탄화
    [SerializeField] private bool m_AirControl = false;                             //점프 중에도 조작 할 수 있는지 여부
    [SerializeField] private LayerMask m_WhatlsGround;                              //캐릭터에게 땅이 무엇인지 결벙하는 마스크
    [SerializeField] private Transform m_GroundCheck;                               //플레이어가 땅에 닿았는지 확인하는 위치
    [SerializeField] private Transform m_WallChesk;                                 //플레이어가 벽에 닿았는지 확인하는 위치

    const float k_GroundedRadius = 0.2f;                            //땅에 닿았는지 확인하는 겹침 원의 반경
    private bool m_IsGrounded;                                      //플레이어가 땅에 닿았는지 여부
    private Rigidbody2D m_Rigidbody2D;                              
    private bool m_facingRight = true;                              //플레이어가 현재 어느 방향을 바라보고 있는 지 결정
    private Vector3 velocity = Vector3.zero;                        //속도
    private float limitFallSpeed = 25f;                             //낙하 속도 제한

    public bool canDoubleJump = true;                               //플레이어가 더블 점프를 할 수 있는지 여부
    private bool m_IsWall = false;                                  //플레이어 앞에 벽이 있는지 여부
    private bool m_IsWallSlidding = false;                          //플레이어가 벽을 타고 있는지 여부
    private bool oldWallSlidding = false;                           //이전 프레임에서 플레이어가 벽을 타고 있었는지 여부
    private float prevVelocityX = 0f;               
    private bool canCheck = false;                                  //플레이어가 벽을 타고 있는지 확인하기 위한 여부

    private Animator animator;

    private float jumpWallStartX = 0;
    private float jumpWallDistX = 0;                    //플레이어와 벽 사이의 거리
    private bool limitVelOnWallJump = false;            //낮은 FPS에서 벽 점프 거리를 제한하기 위한 변수


}
