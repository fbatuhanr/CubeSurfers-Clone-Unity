using DG.Tweening;
using TMPro;
using UnityEngine;

public class CompletedResultsUI : MonoBehaviour
{
    [SerializeField] private RectTransform background;
    [SerializeField] private TextMeshProUGUI scoreMultiplierLabel, scoreLabel;
    public void Enable()
    {
        var multiplierAmount = GameManager.Instance.reachedLastMultiplier-1;
        var collectedStarCount = GameManager.Instance.collectedStarCount;

        var totalScore = multiplierAmount * collectedStarCount;
        
        scoreMultiplierLabel.SetText($"x {multiplierAmount} Multiplier!");
        scoreLabel.SetText(totalScore.ToString());
        
        
        background.DOScale(Vector3.one, 0.25f);
    }

    public void Disable()
    {
        background.DOScale(Vector3.zero, 0.25f);
    }
}
