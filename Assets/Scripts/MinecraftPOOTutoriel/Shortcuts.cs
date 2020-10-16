using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// raccourcis claviers
public static class Shortcuts
{
    // Shortcuts camera
    public static KeyCode leftRotateCameraKey = KeyCode.LeftArrow;
    public static KeyCode rightRotateCameraKey = KeyCode.RightArrow;
    public static KeyCode moveForwardCameraKey = KeyCode.UpArrow;
    public static KeyCode moveUpCameraKey = KeyCode.W;
    public static KeyCode moveBackwardCameraKey = KeyCode.DownArrow;
    public static KeyCode moveDownCameraKey = KeyCode.S;

    // Shortcuts builder tool
    public static KeyCode builderToolScaleXupKey = KeyCode.T;
    public static KeyCode builderToolScaleXdownKey = KeyCode.Y;
    public static KeyCode builderToolScaleYupKey = KeyCode.G;
    public static KeyCode builderToolScaleYdownKey = KeyCode.H;
    public static KeyCode builderToolScaleZupKey = KeyCode.B;
    public static KeyCode builderToolScaleZdownKey = KeyCode.N;
    public static KeyCode builderToolScaleGlobalupKey = KeyCode.U;
    public static KeyCode builderToolScaleGlobaldownKey = KeyCode.I;
    
    public static KeyCode addBlocksKey = KeyCode.Space;
    public static KeyCode removeBlocksKey = KeyCode.Delete;

    public static KeyCode blockBehaviourRotate = KeyCode.R;
    public static KeyCode setStartingBlockKey = KeyCode.O;
    public static KeyCode setEndingBlockKey = KeyCode.P;

    public static KeyCode toggleGameStateKey = KeyCode.L;
    public static KeyCode respawnPlayerKey = KeyCode.A;

    public static KeyCode saveLevelKey = KeyCode.Return;
    public static KeyCode loadLevelKey = KeyCode.C;
    
    public static KeyCode moveUpRaycastzone = KeyCode.J;
    public static KeyCode moveDownRaycastzone = KeyCode.K;


}
