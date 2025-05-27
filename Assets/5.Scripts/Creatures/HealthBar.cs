using UnityEngine;

/// <summary>
/// 체력을 표시하는 HealthBar SpriteRenderer를 활용
/// </summary>
public class HealthBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer foreground;

    private float initialWidth;

    private void Awake()
    {
        if (foreground == null)
        {
            return;
        }
        initialWidth = foreground.transform.localScale.x;
        SetHealthRatio(1f);
    }

    public void SetHealthRatio(float ratio)
    {
        ratio = Mathf.Clamp01(ratio);
        Vector3 scale = foreground.transform.localScale;
        scale.x = initialWidth * ratio;
        foreground.transform.localScale = scale;
    }
}
