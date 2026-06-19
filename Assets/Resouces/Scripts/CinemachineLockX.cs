using UnityEngine;
using Unity.Cinemachine; 
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] 
public class CinemachineLockX : CinemachineExtension
{
    
    public float m_XPosition = 0f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, 
        ref CameraState state, 
        float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            Vector3 pos = state.RawPosition;
            
            pos.x = m_XPosition;
            
            state.RawPosition = pos;
        }
    }
}