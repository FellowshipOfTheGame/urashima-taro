using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(ZombieFieldOfView))]
public class FieldOfViewEditor : MonoBehaviour
{
   /* private void OnSceneGUI()
    {
        ZombieFieldOfView fov = (ZombieFieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.right, 360, fov.radiusVision);
        Handles.color = Color.blue;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.right, 360, fov.radiusHearing);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.z, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.z, fov.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, (fov.transform.position + viewAngle01 * fov.radiusVision));
        Handles.DrawLine(fov.transform.position, (fov.transform.position + viewAngle02 * fov.radiusVision));


        if (fov.canSeePlayer)
        {
            Handles.color = Color.red;
            Handles.DrawLine(fov.transform.position, fov.player.transform.position);
        }
        
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3((-1)*Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }*/
}
