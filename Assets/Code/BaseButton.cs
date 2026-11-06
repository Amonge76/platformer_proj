using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using Sequence = DG.Tweening.Sequence;
using System.Runtime.CompilerServices;
using System.Numerics;



public class BaseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ButtonType _buttonType;
    [SerializeField] private Button _button;

    private EventBus _eventBus;
    [SerializeField] private RectTransform _buttonRect;
    [SerializeField] private float _scaleFactor = 1.2f;
    [SerializeField] private float _duration = 0.2f;
    [SerializeField] private float _clickDuration = 2f;
    [SerializeField] private Image _image;
    private Tween _scaleTween;
    private Sequence _clickSequence;

    private void OnEnable()
    {
        _eventBus = GameManager.Instance.Inet;
        _button.onClick.AddListener(OnClick);
        
    }

    private void OnDisable()
    {
         _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {

        PlayClick();

    }

    private void PlayClick()
    {
        _clickSequence?.Kill(); //kill animation

        // do not start
        _button.interactable = false;

        _clickSequence = DOTween.Sequence()
                        .SetUpdate(true)
                        .SetLink(gameObject)
                        .OnStart(() => {Debug.Log("fixed allllll error");})
                        .Append(_buttonRect.DORotate(new UnityEngine.Vector3(0,0,-360), _clickDuration, RotateMode.FastBeyond360).SetEase(Ease.InSine))
                        .Join(_image.DOFade(0.2f, _clickDuration))
                        .OnComplete(() => {SendPayload();});
    }

    private void SendPayload()
    {
          _eventBus.TriggerButton(_buttonType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _scaleTween?.Kill();//kill animation

        _scaleTween = _buttonRect.DOScale(_scaleFactor, _duration)
                        .SetEase(Ease.OutQuad)
                        .SetUpdate(true)
                        .SetLink(gameObject);
                        //plz no no error

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _scaleTween?.Kill();//kill animation

        _scaleTween = _buttonRect.DOScale(1f, _duration)
                        .SetEase(Ease.InQuad)
                        .SetUpdate(true)
                        .SetLink(gameObject);
                        //plz no no error

    }
   
}
