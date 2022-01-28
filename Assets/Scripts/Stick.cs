using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Stick : MonoBehaviour
{
    private Image _image;
    public float Radius => _image.rectTransform.sizeDelta.x / Mathf.Sqrt(Mathf.PI);
    public Vector3 Center {get; set;}
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        Enabled(false);
    }

    public void Enabled(bool state)
    {
        _image.enabled = state;
    }

    public void Move(Vector3 startPoin, Vector3 endPoint, float Radius)
    {
        Vector3 direction = endPoint - startPoin;
        float touchDistance = Mathf.Abs(Vector3.Distance(startPoin, endPoint));

        if (touchDistance > Radius)
        {
            transform.position = Center + direction.normalized * Radius;
        }else
        {
            transform.position = Input.mousePosition;
        }
    }


}
