using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float movementMultiplier = 10;
    [SerializeField] float turnSmoothTime = 0.001f;

    InputManager inputManager;

    void Start()
    {
        cam = Camera.main;

        inputManager = InputManager.Instance;

        inputManager.OnForward += OnHorizontal;
        inputManager.OnBackward += OnHorizontal;
        inputManager.OnRightward += OnVertical;
        inputManager.OnLeftward += OnVertical;
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
}
