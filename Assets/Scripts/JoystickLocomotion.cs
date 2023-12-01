using System.Collections;
using System.Collections.Generic;
using UnityEditor;
// using UnityEditor.Media;
using UnityEngine;

public class JoystickLocomotion : MonoBehaviour
{
    public GameObject player;
    public Transform head;
    public float speed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        // Use the camera forward and right direction.
        var joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);
        float fixedY = player.transform.position.y;
        player.transform.position += (head.transform.right * joystickAxis.x + head.transform.forward * joystickAxis.y) * Time.deltaTime * speed;
        player.transform.position = new Vector3(player.transform.position.x, fixedY, player.transform.position.z);        
    }
}
