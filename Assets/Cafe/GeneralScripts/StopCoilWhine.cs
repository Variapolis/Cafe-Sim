using UnityEngine;

public class StopCoilWhine : MonoBehaviour
{
    [SerializeField] private bool CursorFree;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorFree ? CursorLockMode.Confined : CursorLockMode.Locked;
        Cursor.visible = CursorFree;
    }
}