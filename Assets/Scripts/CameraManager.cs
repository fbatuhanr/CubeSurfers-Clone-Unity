using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private CinemachineVirtualCamera followCam;
    [SerializeField] private int cameraVisibleStackCapacity = 7;
    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseCameraHeight(int stackCount, Vector3 amount)
    {
        if (stackCount < cameraVisibleStackCapacity) return;

        var followCamTransposer = followCam.GetCinemachineComponent<CinemachineTransposer>();
        
        var newFollowOffset = followCamTransposer.m_FollowOffset + amount;
        
        DOTween.To(()=> followCamTransposer.m_FollowOffset, x=> followCamTransposer.m_FollowOffset = x, newFollowOffset, .5f);
    }

    public void DecreaseCameraHeight(int stackCount, Vector3 amount)
    {
        if (stackCount < cameraVisibleStackCapacity) return;
        
        var followCamTransposer = followCam.GetCinemachineComponent<CinemachineTransposer>();
        
        var newFollowOffset = followCamTransposer.m_FollowOffset - amount;
        
        DOTween.To(()=> followCamTransposer.m_FollowOffset, x=> followCamTransposer.m_FollowOffset = x, newFollowOffset, .5f);
    }
}
