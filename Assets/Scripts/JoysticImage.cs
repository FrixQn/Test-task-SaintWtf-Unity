using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class JoysticImage : MonoBehaviour
{
    private Image _image;
    public float Radius => _image.rectTransform.sizeDelta.x / Mathf.Sqrt(Mathf.PI); 
    private void Awake()
    {
        _image = GetComponent<Image>();
        Enabled(false);
    }

    public void Enabled(bool state)
    {
        transform.position = Input.mousePosition;
        _image.enabled = state;
    }
}
