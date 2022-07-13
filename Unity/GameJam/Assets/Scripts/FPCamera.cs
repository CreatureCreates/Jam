using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    private GameObject Player;
    public float sensitivity;
    float rotateHorizontal;
    float rotateVertical;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Player.transform.position;

        Transform ShootingPoint = GameObject.FindGameObjectWithTag("ShootingPoint").transform;
        print(ShootingPoint);
        transform.LookAt(ShootingPoint, Vector3.up);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // put the camera at the coördinates of the player
        transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + 0.2f, Player.transform.position.z);

        // rotate the camera in the horizontal direction the mouse points
        rotateHorizontal = Input.GetAxis ("Mouse X");
        transform.RotateAround (Player.transform.position, -Vector3.up, -rotateHorizontal * sensitivity * Time.deltaTime);

        // rotate the camera in the vertical direct the mouse points
        rotateVertical = Input.GetAxis ("Mouse Y");
        transform.RotateAround (Vector3.zero, transform.right, -rotateVertical * sensitivity * Time.deltaTime);
    }
}
