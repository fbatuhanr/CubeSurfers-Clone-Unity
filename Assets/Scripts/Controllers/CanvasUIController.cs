using UnityEngine;

public class CanvasUIController : MonoBehaviour
{
    public static CanvasUIController Instance;

    public CollectedStarsUI collectedStarsUI;
    public CompletedResultsUI completedResultsUI;
    public GameoverResultsUI gameoverResultsUI;
    
    private void Awake()
    {
        Instance = this;
    }
}
