using TMPro;
using UnityEngine;

public class EscapeTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI escapeText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show ()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public string Text
    {
        set
        {
            escapeText.text = value;
        }
    }
}
