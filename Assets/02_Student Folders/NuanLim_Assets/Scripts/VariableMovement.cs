using UnityEngine;

[RequireComponent(typeof(PlayerCharacterController))]
public class VariableMovement : MonoBehaviour {
    private PlayerCharacterController _controller;

    private float _jump;
    private float _speed;

    private void Start() {
        _controller = GetComponent<PlayerCharacterController>();
        _jump = _controller.jumpForce;
        _speed = _controller.maxSpeedOnGround;
    }

    private void OnTriggerEnter(Collider coll) {
        VariableMovementTrigger t = coll.GetComponent<VariableMovementTrigger>();

        if (t) {
            _controller.jumpForce *= t.jumpMultiplier;
            _controller.maxSpeedOnGround *= t.speedOnGroundMultiplier;
        }
    }

    private void OnTriggerExit(Collider coll) {
        _controller.jumpForce = _jump;
        _controller.maxSpeedOnGround = _speed;
    }
}
