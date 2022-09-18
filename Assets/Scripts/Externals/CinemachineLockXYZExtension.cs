using UnityEngine;
using Cinemachine;
 
/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Z co-ordinate
/// </summary>
[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class LockCameraXYZ : CinemachineExtension
{
    [Tooltip("Choose camera axis X-Y-Z for lock")]
    public enum Position { X,Y,Z }  
    public Position positions;
    
    [Tooltip("Lock the camera's X-Y-Z position to this value")]
    public float m_Position = 0;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            switch (positions) {
                case Position.X: pos.x = m_Position; break;
                case Position.Y: pos.y = m_Position; break;
                case Position.Z: pos.z = m_Position; break;
                default: pos.x = m_Position; break;
            }
            state.RawPosition = pos;
        }
    }
}