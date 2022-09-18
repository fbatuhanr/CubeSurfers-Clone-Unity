using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverResultsUI : MonoBehaviour
{
    [SerializeField] private RectTransform background;
    
    public void Enable()
    {
        background.DOScale(Vector3.one, 0.25f);
    }

    public void Disable(bool restartAfterDisable = false)
    {
        background
            .DOScale(Vector3.zero, 0.25f)
            .OnComplete(() => { 
                if(restartAfterDisable) 
                    ReloadCurrentScene();
            });
    }
    public void Restart()
    {
        Disable(true);
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
