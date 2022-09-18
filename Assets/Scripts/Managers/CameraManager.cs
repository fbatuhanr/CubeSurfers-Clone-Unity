using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private CinemachineVirtualCamera followCam;
    [SerializeField] private int cameraVisibleStackCapacity = 7;

    private CinemachineTransposer followCamTransposer; 
    private Vector3 cameraBeginningOffset;

    [SerializeField] private CinemachineVirtualCamera finishAreaCam;
    private void Awake()
    {
        Instance = this;

        followCamTransposer = followCam.GetCinemachineComponent<CinemachineTransposer>();
        cameraBeginningOffset = followCamTransposer.m_FollowOffset;
        
        FollowCamPriority();
    }

    public void IncreaseCameraHeight(int stackCount, Vector3 amount)
    {
        if (stackCount < cameraVisibleStackCapacity) return;
        
        var newFollowOffset = followCamTransposer.m_FollowOffset + amount;
        
        DOTween.To(()=> followCamTransposer.m_FollowOffset, x=> followCamTransposer.m_FollowOffset = x, newFollowOffset, .5f);
    }

    public void DecreaseCameraHeight(int stackCount, Vector3 amount)
    {
        Vector3 newFollowOffset;
        if (stackCount < cameraVisibleStackCapacity)
        {
            newFollowOffset = cameraBeginningOffset;
        }
        else
        {
            newFollowOffset = followCamTransposer.m_FollowOffset - amount;
        }
        
        DOTween.To(()=> followCamTransposer.m_FollowOffset, x=> followCamTransposer.m_FollowOffset = x, newFollowOffset, .5f);
    }
    


    private void FollowCamPriority()
    {
        ResetCamPriorities();
        followCam.Priority = 1;
    }
    public void FinishAreaCamPriority()
    {
        ResetCamPriorities();
        finishAreaCam.Priority = 1;
    }
    private void ResetCamPriorities()
    {
        followCam.Priority = 0;
        finishAreaCam.Priority = 0;
    }
}
