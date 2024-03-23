using UnityEngine;
using Cinemachine;

public class Camera3D : MonoBehaviour
{
    public Transform target;

    private CinemachineVirtualCamera virtualCamera;
    private Rigidbody targetRigidbody;
    private Vector3 lastTargetPosition;

    void Start()
    {
        SetupCamera();
    }

    void Update()
    {
        // Actualiza la configuración de la cámara en cada fotograma
        UpdateCameraPosition();
    }

    void SetupCamera()
    {
        // Encuentra o crea una Virtual Camera de Cinemachine
        if (virtualCamera == null)
        {
            virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            if (virtualCamera == null)
            {
                GameObject vcamGameObject = new GameObject("VirtualCamera");
                vcamGameObject.transform.SetParent(transform);
                virtualCamera = vcamGameObject.AddComponent<CinemachineVirtualCamera>();
            }
        }

        // Configura el objetivo de la Virtual Camera
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;

        // Obtiene el Rigidbody del objetivo para seguir su velocidad
        targetRigidbody = target.GetComponent<Rigidbody>();
        lastTargetPosition = target.position;
    }

    void UpdateCameraPosition()
{
    // Calcula el desplazamiento del objetivo desde el último fotograma
    Vector3 targetVelocity = (target.position - lastTargetPosition) / Time.deltaTime;
    lastTargetPosition = target.position;

    // Calcula la posición de la cámara detrás del objetivo
    Vector3 targetBackward = -target.forward; // Obtiene el vector detrás del objetivo
    Vector3 targetOffset = new Vector3(-71.1f, 6.7f, -12f); // Offset de la cámara con respecto al objetivo
    Vector3 newPosition = target.position + targetBackward * targetOffset.z + Vector3.up * targetOffset.y; // Calcula la nueva posición
    transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5); // Suaviza el movimiento de la cámara

    // Obtiene la rotación actual de la cámara y ajusta solo en el eje Y para seguir al objetivo
    Quaternion targetRotation = Quaternion.Euler(0, target.eulerAngles.y, 0);
    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5); // Suaviza la rotación de la cámara
}

}
