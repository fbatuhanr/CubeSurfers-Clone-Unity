using TMPro;
using UnityEngine;

public class CollectedStarsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starLabel;
    public void UpdateStarCount()
    {
        var collectedStarCount = GameManager.Instance.collectedStarCount;
        starLabel.SetText(collectedStarCount.ToString());
    }
}
