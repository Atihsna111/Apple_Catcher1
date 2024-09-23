using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
   [SerializeField] private AudioClip _compressed, _uncompress;
    [SerializeField] private AudioSource _source;
   
     public void OnPointerDown (PointerEventData eventData)
    {
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressed);
        
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        _img.sprite = _default;
        _source.PlayOneShot(_uncompress);

    }
}