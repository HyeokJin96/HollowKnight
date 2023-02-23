using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GData
{
    #region Scene Name
    public const string SCENE_NAME_TITLE = "01.TitleScene(MainMenu)";
    public const string SCENE_NAME_LEVEL01 = "Level01";
    public const string SCENE_NAME_LEVEL02 = "Level02";
    #endregion

    #region Player
    public static float moveInput = default;
    public static float playerSpeed = default;
    public static float playerJumpForce = default;
    public static float attackDelay = default;
    public static float lastAttackTime = default;

    public static float playerHp = default;
    public static float playerSlashDamage = default;
    public static float OldNailDamage = default;
    #endregion

    #region Player Boolean
    public static bool isGrounded = false;
    public static bool isRunning = false;
    public static bool isRightSlash = false;
    public static bool isLeftSlash = false;
    public static bool isDownSlash = false;
    public static bool isUpSlash = false;
    public static bool isJumping = false;
    public static bool isAttacking = false;
    #endregion


}
