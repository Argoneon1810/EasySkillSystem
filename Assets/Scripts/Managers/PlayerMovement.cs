using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float movementMultiplier = 10;
    [SerializeField] float jumpMultiplier = 3;
    [SerializeField] float turnSmoothTime = 0.001f;

    [SerializeField] float jumpableGroundContactAngle = 30;
    [SerializeField] float verticalJumpRecognitionAngle = 20;

    InputManager inputManager;
    Rigidbody mRigidbody;

    void Start()
    {
        cam = Camera.main;
        mRigidbody = GetComponent<Rigidbody>();
        inputManager = InputManager.Instance;

        inputManager.OnForward += OnHorizontal;
        inputManager.OnBackward += OnHorizontal;
        inputManager.OnRightward += OnVertical;
        inputManager.OnLeftward += OnVertical;

        inputManager.OnJump += delegate (float vertical, float horizontal)
        {
            inputManager.inputLock = true;
            Vector3 jumpVector = 
                Vector3.up   * movementMultiplier / 2
                + vertical   * movementMultiplier * cam.transform.forward.ToXZPlainNormalVector()
                + horizontal * movementMultiplier * cam.transform.right.ToXZPlainNormalVector();
            jumpVector.Normalize();
            if (jumpVector.IsAngleBetweenVectorsLessThanGiven(Vector3.up, verticalJumpRecognitionAngle))
                jumpVector /= 2;
            mRigidbody.AddForce(jumpVector * jumpMultiplier);
        };
    }

    private void OnHorizontal(float f)
    {
        transform.position += f * movementMultiplier * Time.deltaTime * cam.transform.right.ToXZPlainNormalVector();
    }

    private void OnVertical(float f)
    {
        transform.position += f * movementMultiplier * Time.deltaTime * cam.transform.forward.ToXZPlainNormalVector();
    }

    private void Update()
    {
        Quaternion toRotation = Quaternion.LookRotation(cam.transform.forward.ToXZPlainNormalVector());
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSmoothTime * Time.time);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            if (collision.GetContact(0).normal.IsAngleBetweenVectorsLessThanGiven(Vector3.up, jumpableGroundContactAngle))
                inputManager.inputLock = false;
        mRigidbody.velocity /= 2;
    }
}
