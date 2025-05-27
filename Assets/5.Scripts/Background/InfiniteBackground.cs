using UnityEngine;

/// <summary>
/// 움직이는 background를 구현하는 클래스
/// </summary>
public class InfiniteBackground : MonoBehaviour
{
    [SerializeField] private Transform[] panels;
    [SerializeField] private float scrollSpeed = 2f;
    private float panelWidth;
    private int leftIndex;
    private int rightIndex;

    void Start()
    {
        if (panels == null || panels.Length < 2)
        {
            enabled = false;
            return;
        }

        var sr = panels[0].GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            enabled = false;
            return;
        }
        panelWidth = sr.bounds.size.x;

        leftIndex = 0;
        rightIndex = panels.Length - 1;
    }

    void Update()
    {
        float delta = scrollSpeed * Time.deltaTime;

        for (int i = panels.Length - 1; i >= 0; i--)
        {
            panels[i].position += Vector3.left * delta;
        }
            
        if (panels[leftIndex].position.x <= -panelWidth)
        {
            Vector3 newPos = panels[rightIndex].position;
            newPos.x += panelWidth;
            panels[leftIndex].position = newPos;

            rightIndex = leftIndex;
            leftIndex = (leftIndex + 1) % panels.Length;
        }
    }
}
