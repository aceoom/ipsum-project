using UnityEngine;

public class EscapeZone : MonoBehaviour
{
    [SerializeField]
    private float time;

    public delegate void EnterHandler(float time);
    public event EnterHandler OnEnter;

    public delegate void ExitHandler();
    public event ExitHandler OnExit;

    private bool IsPlayer(Collider collider)
    {
        return collider.CompareTag("Player");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!IsPlayer(collider)) return;

        OnEnter?.Invoke(time);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!IsPlayer(collider)) return;

        OnExit?.Invoke();
    }
}
