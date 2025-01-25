using UnityEngine;
using DG.Tweening;

public class MainMenuAnimationsScripts : MonoBehaviour
{
    [SerializeField] private RectTransform _titleRect;
    [SerializeField] private RectTransform _ButtonPannelRect;
    private void Start()
    {
        TitleAnimation();
        ButtonPannelAnimation();
    }
    private void TitleAnimation()   
    {
        _titleRect.DOAnchorPosY(-60, 1.5f).SetEase(Ease.OutBounce);
        return;
    }

    private void ButtonPannelAnimation()
    {
        _ButtonPannelRect.DOScale(1, 2).SetEase(Ease.OutBounce);
        return;
    }

}
