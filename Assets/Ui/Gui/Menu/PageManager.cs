using UnityEngine;

[ExecuteInEditMode]
public class PageManager : MonoBehaviour
{
    public Vector2Int currentPage;
    public PageDirection currentDirection;
    public Page[] pages;

    Vector2 screenSize;

    RectTransform pageManagerRect;


    private void Awake()
    {
        pageManagerRect = GetComponent<RectTransform>();
        AlignPages();
    }

    private void Start()
    {
        AlignPages();
    }


    private void Update()
    {
        AlignPages();

        pageManagerRect.anchoredPosition = Vector2.Lerp(pageManagerRect.anchoredPosition, currentPage * screenSize, Time.deltaTime * 6f);
    }

    private void AlignPages()
    {
        screenSize = GetComponentInParent<RectTransform>().rect.size;
        pages = GetComponentsInChildren<Page>(true);

        for (int i = 0; i < pages.Length; i++)
        {
            var rect = pages[i].GetComponent<RectTransform>();
            rect.anchoredPosition = pages[i].pagePosition * screenSize;
        }
    }

    public void ChangePage(PageDirection direction)
    {
        currentDirection = direction;
        currentPage = DirectionToVector(direction);
    }

    public void BackPage()
    {
        var inveseDirection = DirectionToVector(currentDirection);
        currentPage -= inveseDirection;
    }

    Vector2Int DirectionToVector(PageDirection direction)
    {
        return direction switch
        {
            PageDirection.Up => new Vector2Int(0, -1),
            PageDirection.Down => new Vector2Int(0, 1),
            PageDirection.Left => new Vector2Int(1, 0),
            PageDirection.Right => new Vector2Int(-1, 0),
            _ => throw new System.NotImplementedException(),
        };
    }
}
