//https://forum.unity.com/threads/single-eye-render-mode-like-the-gvr-plugin-with-vr-mode-disabled.437274/

using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;
using System.Collections;
 
public class MixedVRCameraController : MonoBehaviour
{

    //[SerializeField] private float fieldOfView = 60f;

    void Start()
    {
        UnityEngine.XR.XRSettings.enabled = false;
        Camera.main.GetComponent<Transform>().localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(XRNode.CenterEye);
        transform.localPosition = new Vector3(0,0,0);
        transform.localRotation = new Quaternion(0,0,0,0);
    }

    void Update()
    {         
        transform.localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
    }
    /*
    public void ToggleVR()
    {
        SetVR(!UnityEngine.XR.XRSettings.enabled);
        if(UnityEngine.XR.XRSettings.enabled){
        	transform.localPosition = new Vector3(0,0,0);
            transform.localRotation = new Quaternion(0,0,0,0);
        }
    }
 
    public void SetVR(bool enabled)
    {
        UnityEngine.XR.XRSettings.enabled = enabled;
    }*/
}