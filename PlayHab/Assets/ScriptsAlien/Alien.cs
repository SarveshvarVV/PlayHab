using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite hog;
    [SerializeField] private Sprite hogHit;
    [SerializeField] private Sprite bomb;
    [SerializeField] private Sprite bombHit;

    [Header("GameManager")]
    [SerializeField] private GameControllerAlien gameManager;

    [Header("Mechanics")]
    [SerializeField] private float duration = 1f;

    // Groundhog positions 
    private Vector2 startPosition = new Vector2(0f, -13f);
    private Vector2 endPosition = Vector2.zero;

    // Groundhog duration
    private float showDuration = 0.5f;
    

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Vector2 boxOffset;
    private Vector2 boxSize;
    private Vector2 boxOffsetHidden;
    private Vector2 boxSizeHidden;

    // groundhog Parameters
    private bool hittable = true;
    public enum HogType { Standard, Bomb};
    private HogType hogType;
    private float bombRate = 0.1f;
    private int hogIndex;

    public void Activate() 
    {
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    private void CreateNext()
    {
        float random = Random.Range(0f, 1f);
        if (random < bombRate)
        {
            // create bomb
            hogType = HogType.Bomb;
            spriteRenderer.sprite = bomb;
        }
        else
        {
            
            // create normal hog
            hogType = HogType.Standard;
            spriteRenderer.sprite = hog;
            
        }
        // Make it hittable 
        hittable = true;
    }

    private void Awake() 
    {
        // component references
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        // collider values
        boxOffset = boxCollider2D.offset;
        boxSize = boxCollider2D.size;
        boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f);
        boxSizeHidden = new Vector2(boxSize.x, 0f);
    }

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // groundhog under the hole
        transform.localPosition = start;

        // groundhog appearing
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed/showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // groundhog above the hole
        transform.localPosition = end;
        boxCollider2D.offset = boxOffset;
        boxCollider2D.size = boxSize;

        // groundhog still duration
        yield return new WaitForSeconds(duration);

        // groundhog hiding
        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed/showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffset, boxOffsetHidden, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSize, boxSizeHidden, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // groundhog back under the hole
        transform.localPosition = start;
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;

        if(hittable)
        {
            hittable = false;
            gameManager.Missed(hogIndex);
        }
    }

    private void OnMouseDown() 
    {
        if (hittable)
        {
            switch(hogType)
            {
                case HogType.Standard:
                    spriteRenderer.sprite = hogHit;
                    gameManager.Whacked(hogIndex);
                    // stop groundhog movement
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());
                    // turn off hittable for no duplicate score
                    hittable = false;
                    break;
                case HogType.Bomb:
                    spriteRenderer.sprite = bombHit;
                    gameManager.BombHit(hogIndex);
                    // stop bomb movement
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());
                    // turn off hittable for no duplicate score
                    hittable = false;
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);
        // So that another hog doesn't spawn
        if (!hittable)
        {
            Hide();
        }
    }

    public void Hide()
    {
        transform.localPosition = startPosition;
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;
    }
    public void SetIndex(int index) 
    {
        hogIndex = index;
    }
}