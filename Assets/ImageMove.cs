using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ScoreManager
public class score
{
    public static int GameScore=0;
}
//[RequireComponent(typeof(CanvasGroup))]
public class ImageMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rect;
    private Vector3 startPos;
    private AudioSource audioSource;
    public AudioClip successClip;
    public AudioClip failureClip;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        startPos = rect.localPosition;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on this GameObject");
        }

        if (successClip == null)
        {
            Debug.LogError("Success AudioClip is not assigned");
        }

        if (failureClip == null)
        {
            Debug.LogError("Failure AudioClip is not assigned");
        }
    }

    public void SetPosition(PointerEventData eventData)
    {
        Vector3 finalPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out finalPos))
        {
            rect.position = finalPos;
        }
    }

    //开始拖曳
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        GetComponent<Image>().raycastTarget = false;
        SetPosition(eventData);
    }

    //拖曳中
    public void OnDrag(PointerEventData eventData)
    {
        SetPosition(eventData);
    }

    //拖拽结束
    public void OnEndDrag(PointerEventData eventData)
    {
        SetPosition(eventData);
        if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<ImageMove>() == null)//这里是拖动图片的时候只有拖动
        {                                                                                             //到垃圾桶才执行代码
            if (eventData.pointerEnter.CompareTag(transform.tag))
            {
                //标签相同加分 垃圾图片消失
                transform.gameObject.SetActive(false);
                Debug.Log("Playing success sound"); // 调试信息
                PlaySound(successClip);  // 播放成功音效
                switch (transform.tag)
                {
                    case "bottle":
                        score.GameScore += 10;
                        break;
                    case "trash":
                        score.GameScore += 10;
                        break;
                    case "paper":
                        score.GameScore += 10;
                        break;
                    case "food":
                        score.GameScore += 10;
                        break;
                }
            }
            else
            {
                //标签不同扣分 垃圾图片恢复原位
                GetComponent<RectTransform>().localPosition = startPos;
                PlaySound(failureClip);  // 播放失败音效
                switch (transform.tag)
                {
                    case "bottle":
                        score.GameScore -= 10;
                        break;
                    case "trash":
                        score.GameScore -= 10;
                        break;
                    case "paper":
                        score.GameScore -= 10;
                        break;
                    case "food":
                        score.GameScore -= 10;
                        break;
                }
            }
            // Debug.Log(score.GameScore);
            ScoreManager.Score= score.GameScore;
            
        }
        else
        {
            GetComponent<RectTransform>().localPosition = startPos;
        }
        GetComponent<Image>().raycastTarget = true;
    }
    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            if (!audioSource.enabled)
            {
                audioSource.enabled = true;
            }
            Debug.Log("Playing sound: " + clip.name);
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("AudioSource or AudioClip is null");
        }
    }
}
