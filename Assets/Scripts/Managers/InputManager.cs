using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action<float> OnForward;
    public event Action<float> OnBackward;
    public event Action<float> OnLeftward;
    public event Action<float> OnRightward;

    public event Action OnCollect;

    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0) OnForward?.Invoke(horizontal);
        if (horizontal < 0) OnBackward?.Invoke(horizontal);
        if (vertical > 0) OnRightward?.Invoke(vertical);
        if (vertical < 0) OnLeftward?.Invoke(vertical);

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) OnCollect?.Invoke();
    }
}
