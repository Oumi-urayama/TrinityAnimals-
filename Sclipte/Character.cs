using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// プレイヤー操作スクリプトの親クラス
/// </summary>
public class Character : MonoBehaviour
{
    //移動速度
    [SerializeField,Header("移動速度")]
    protected float movementSpeed;
    //ジャンプ力
    [SerializeField,Header("ジャンプ力")]
    protected float jumpForce;
    //重力
    [SerializeField,Header("重力")]
    protected float gravityValue;
    //スキルのクールタイム
    [SerializeField,Header("スキルクールタイム")]
    protected float skillCoolTime;
    //代入するクールタイムの値
    [SerializeField,Header("クールタイムの最大値")]
    protected float coolTime;
    //次のジャンプまでにかかる時間
    [SerializeField,Header("ジャンプ待機時間")]
    protected float timeBeforeNextJump;
    //ジャンプまでにかかる時間を代入した時間
    [SerializeField,Header("ジャンプが可能になる時間")]
    protected float canJump;
    //キャラクターの回転のスピード
    [SerializeField,Header("キャラクターの回転速度")]
    protected float rotateSpeed;
    //各種コンポーネントのインスタンス
    protected Animator anim;
    protected Rigidbody rb;
    protected PlayerInput playerInput;
    protected CharacterController charaCon;
    //プレイヤーのベクトル
    protected Vector3 playerVelocity;
    //カメラコントローラーのインスタンス
    CameraController cameraController;
    [Header("フラグマネージャー")]
    public FlagManager myFlagManager;

    //スタートメゾット
    void Start()
    {
        myFlagManager = FindObjectOfType<MyFlagManager>().GetFlagManagerDate();
        //各種コンポーネントの習得
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        charaCon = GetComponent<CharacterController>();
        cameraController = GetComponentInChildren<CameraController>();
        //もしカメラコントローラーが空っぽでなければ
        if (cameraController != null)
        {
            //カメラコントローラーを有効化
            cameraController.enabled = true;
        }
    }

    //毎フレームごとに
    void Update()
    {
        //playerInputが空っぽなら
        if (playerInput == null)
            //エラーを返す
            return;
        //gameOver・gameClear・gamePauseの全てのフラグがfalseの時
        if (!myFlagManager.GameOver && !myFlagManager.GameClear && !myFlagManager.GamePause)
        {
            //ControllPlayerメゾットを動かす
            ControllPlayer();
        }
        //playerInputで["Pause"]が押されたとき
        if (playerInput.actions["Pause"].triggered)
        {
            //gamePauseをtrueにする
            myFlagManager.GamePause = true;
        }
    }

    //ControllPlayerメゾット
    public virtual void ControllPlayer()
    {
        //moveInputにplayerInputで入力された["Move"]の方向ベクトルを代入する
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();

        //moveInputのベクトルのx成分とy成分をそれぞれ最も近い整数に丸める
        moveInput = new Vector2(Mathf.Round(moveInput.x), Mathf.Round(moveInput.y));

        //y軸方向の成分を無視して正規化（ベクトルの長さを1に調整）
        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized; 
        // Y軸を無視することで水平方向のみを考慮
        cameraForward.y = 0;

        //moveInputをもとにプレイヤーを水平方向のベクトルをmoveDirectionに入れる
        Vector3 moveDirection = moveInput.y * cameraForward + moveInput.x * Camera.main.transform.right;

        //もしmoveDirectionが0でないなら
        if (moveDirection != Vector3.zero)
        {
            // プレイヤーの向きを入力方向に向ける
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            //プレイヤーを回転させる
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }

        //プレイヤーを移動させる
        charaCon.Move(moveDirection * Time.deltaTime * movementSpeed);

        //moveInputに入力がある時
        if (moveInput != Vector2.zero)
        {
            //Walkアニメーションを動かす
            anim.SetInteger("Walk", 1);
        }
        else
        {
            //Walkアニメーションを止める
            anim.SetInteger("Walk", 0);
        }

        //["Jamp"]入力があり、かつcamJumpよりも時間が経過している時
        if (playerInput.actions["Jamp"].triggered && Time.time > canJump)
        {
            //playerVelocityにy軸にjumpForceを入れたベクトルを格納する
            playerVelocity = new Vector3(0f, jumpForce, 0f);
            //ジャンプさせる
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //canJumpnにその時の時間とtimeBeforeNextJumpを足した値を入れる
            canJump = Time.time + timeBeforeNextJump;
            //ジャンプアニメーションを動かす
            anim.SetTrigger("jump");
        }
        // 重力
        playerVelocity.y += gravityValue * Time.fixedDeltaTime;
        charaCon.Move(playerVelocity * Time.fixedDeltaTime);
    }
    //colliderのtriggerに触れた時
    public void OnTriggerEnter(Collider other)
    {
        //接触したのがDeadタグのオブジェクトの時
        if (other.gameObject.tag == "Dead")
        {
            //gameOverをtrueにする
            myFlagManager.GameOver = true;
        }
        //接触したのがGoalタグのオブジェクトの時
        else if (other.gameObject.tag == "Goal")
        {
            //gameClearをtrueにする
            myFlagManager.GameClear = true;
        }
    }
}