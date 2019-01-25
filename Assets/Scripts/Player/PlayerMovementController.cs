using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public float playerSpeed = 10f;
    Vector3 mousePos = new Vector3();
    Vector3 relativeMousePos = new Vector3();
    Vector3 objectPos = new Vector3();
    void Start() {

    }

    void Update() {
        Movement();
    }

    void Movement() {
        if (Input.GetKey("up")) {
            transform.Translate(0, playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("down")) {
            transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("right")) {
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("left")) {
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
    }

    //360 degree rotation
    void RotatePlayerTowardsMouse() {
        relativeMousePos = MousePositionRelativeToPlayer();
        float rotationAngel = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngel));
    }

    //eight side rotation
    void AngularPlayerRotationTowardsMouse() {
        Debug.Log(MousePositionRelativeToPlayer());
    }

    Vector3 MousePositionRelativeToPlayer() {
        mousePos = Input.mousePosition;
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        return mousePos - objectPos;
    }
}
