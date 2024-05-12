using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using Cinemachine;
using UnityEditor.Rendering.LookDev;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Header("Player State")]
    [SerializeField] bool IsInWater;

    [Space]

    [Header("Camera")]
    [SerializeField] GameObject cameraObject;

    [SerializeField] float cameraSensitivity;
    [Space]
    [SerializeField] float walkCameraShakeIntensity;
    [SerializeField] float runCameraShakeIntensity;
    [SerializeField] float shakeIntensity;
    [Space]
    [SerializeField] float walkCameraPOV;
    [SerializeField] float runCameraPOV;
    [SerializeField] float POVTransition;

    float xAxisCameraRot = 0f;
    float currentCameraShake;
    float currentCameraPOV;
    CinemachineVirtualCamera virtualPlayerCamera;

    [Space]

    [Header("Player Stats")]
    [SerializeField] float playerWalkMovementSpeed;
    [SerializeField] float playerRunMovementSpeed;
    [SerializeField] float movementTransition;
    [Space]
    [SerializeField] float playerStamina;
    [SerializeField] float playerStaminaUsage;
    [SerializeField] float playerIdleStaminaRegen;
    [SerializeField] float playerWalkStaminaRegen;

    private bool isRunning = false;
    private float maxPlayerStamina = 0;
    private float currentPlayerMovementSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentCameraShake = walkCameraShakeIntensity;
        currentCameraPOV = walkCameraPOV;
        currentPlayerMovementSpeed = playerWalkMovementSpeed;
        currentPlayerMovementSpeed *= GameManager.Instance.speedMultiplier;

        rb = GetComponent<Rigidbody>();
        virtualPlayerCamera = cameraObject.GetComponent<CinemachineVirtualCamera>();

        maxPlayerStamina = playerStamina;
    }

    void Update()
    {
        //Camera
        CameraMovement();
        CameraShake();
        CameraPov();

        //Je li player trèi
        PlayerMovementState();
        StaminaSystem();
    }

    
    void FixedUpdate()
    {
        //Je li se player nalazi na površini ili u moru
        if (!IsInWater) GroundMovement(GetKeyboardInput());
        else WaterMovement(GetKeyboardInput());
    }

    private Vector3 GetKeyboardInput()
    {
        float yAxisInput;

        if (Input.GetKey(KeyCode.Q)) yAxisInput = -1f;
        else if (Input.GetKey(KeyCode.E)) yAxisInput = 1f;
        else yAxisInput = 0f;

        Vector3 keyboardInput = new Vector3(Input.GetAxis("Horizontal"), yAxisInput, Input.GetAxis("Vertical")).normalized;
        
        return keyboardInput;
    }

    private void PlayerMovementState()
    {
        bool runningConditionsMet = (Input.GetKey(KeyCode.LeftShift) && (GetKeyboardInput() != Vector3.zero) && (playerStamina >= 0f));
        isRunning = runningConditionsMet;

        float maxPlayerMovementSpeed = (runningConditionsMet ? playerRunMovementSpeed : playerWalkMovementSpeed) * 100f;

        if (currentPlayerMovementSpeed > maxPlayerMovementSpeed) currentPlayerMovementSpeed -= movementTransition * Time.deltaTime;
        else if (currentPlayerMovementSpeed < maxPlayerMovementSpeed) currentPlayerMovementSpeed += movementTransition * Time.deltaTime;
    }

    private void StaminaSystem()
    {
        if (playerStamina < maxPlayerStamina && !isRunning)
        {
            if (rb.velocity == Vector3.zero) playerStamina += playerIdleStaminaRegen * Time.deltaTime;
            else playerStamina += playerWalkStaminaRegen * Time.deltaTime;
        }
        else playerStamina -= playerStaminaUsage * Time.deltaTime;
    }

    private void GroundMovement(Vector3 input)
    {
        Vector3 moveDir = transform.TransformDirection(new Vector3(input.x, 0, input.z)) * currentPlayerMovementSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
    }

    private void WaterMovement(Vector3 input)
    {
        Vector3 moveDir = transform.TransformDirection(new Vector3(input.x, input.y, input.z)) * currentPlayerMovementSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(moveDir.x, 0, moveDir.z);
        rb.AddForce(new Vector3(0, input.y * 100f, 0));

    }

    private void CameraMovement()
    {
        //Input
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        mouseInput *= cameraSensitivity;

        xAxisCameraRot -= mouseInput.y;
        xAxisCameraRot = Mathf.Clamp(xAxisCameraRot, -90f, 90f);


        //Camera rotation
        if (!IsInWater)
        {
            cameraObject.transform.localEulerAngles = new Vector3(xAxisCameraRot, 0f, 0f);
            transform.Rotate(new Vector3(0f, mouseInput.x, 0));
        }
        else
        {
            //transform.Rotate(new Vector3(-mouseInput.y, mouseInput.x, 0f));
            cameraObject.transform.localEulerAngles = new Vector3(xAxisCameraRot, 0f, 0f);
            transform.Rotate(new Vector3(0f, mouseInput.x, 0));
        }
    }

    private void CameraShake()
    {
        float maxCameraShake = isRunning ? runCameraShakeIntensity : walkCameraShakeIntensity;

        if (currentCameraShake > maxCameraShake) currentCameraShake -= shakeIntensity * Time.deltaTime;
        else if (currentCameraShake < maxCameraShake) currentCameraShake += shakeIntensity * Time.deltaTime;

        virtualPlayerCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = currentCameraShake;
        virtualPlayerCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = currentCameraShake * 0.5f;
    }

    private void CameraPov()
    {
        float maxCameraPOV = isRunning ? runCameraPOV : walkCameraPOV;

        if (currentCameraPOV > maxCameraPOV) currentCameraPOV -= POVTransition * Time.deltaTime;
        else if (currentCameraPOV > maxCameraPOV) currentCameraPOV += POVTransition * Time.deltaTime;

        virtualPlayerCamera.m_Lens.FieldOfView = currentCameraPOV;
    }
}
