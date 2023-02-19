using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GData
{
    public const string SCENE_NAME_TITLE = "01.TitleScene(MainMenu)";
    public const string SCENE_NAME_PLAY = "02.PlayScene";

    public static float moveInput = default;
    public static float playerSpeed = default;
    public static float playerJumpForce = default;
    public static float attackDelay = default;
    public static float lastAttackTime = default;

    public static bool isGrounded = false;
    public static bool isRunning = false;
    public static bool isRightSlash = false;
    public static bool isLeftSlash = false;
    public static bool isJumping = false;
    public static bool isAttacking = false;

}
