using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GData
{
    public const string SCENE_NAME_TITLE = "01.TitleScene(MainMenu)";
    public const string SCENE_NAME_LEVEL01 = "Level01";
    public const string SCENE_NAME_LEVEL02 = "Level02";

    public static float moveInput = default;
    public static float playerSpeed = default;
    public static float playerJumpForce = default;
    public static float attackDelay = default;
    public static float lastAttackTime = default;

    public static float playerHp = default;
    public static float playerSlashDamage = default;
    public static float OldNailDamage = default;

    public static bool isGrounded = default;
    public static bool isRunning = default;
    public static bool isRightSlash = default;
    public static bool isLeftSlash = default;
    public static bool isDownSlash = default;
    public static bool isUpSlash = default;
    public static bool isJumping = default;
    public static bool isAttacking = default;

    public static bool isFalseKnightAppear = default;
}
