using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private RectTransform inventoryRect;

    private float inventoryWidth, inventoryHight;

    public int slots;
    public int rows;
    public float slotPaddingLeft, slotPaddingTop;
    public float slotSize;
    public GameObject slotPrefab;

    public GameObject iconPrefab;

    private static GameObject hoverObject;

    public Canvas canvas;
    private static CanvasGroup canvasGroup;

    float hoverYOffset;

    public EventSystem eventSystem;


    private static Slot from, to;

    private List<GameObject> allSlots;

    private static int emptySlots;

    private static GameObject clicked;

    public GameObject selectStackSize;
    public Text stackText;
    private int splitAmount;
    private int maxStackCount;
    private static Slot movingSlot;


    bool fadingIn;
    bool fadingOut;

    public float fadeTime;

    public static int EmptySlots { get => emptySlots; set => emptySlots = value; }
    public static CanvasGroup CanvasGroup { get => canvasGroup;}
    public static Inventory Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Inventory>();
            }
            return Inventory.instance;
        }
    }

    private static Inventory instance;

    void CreateLayout ()
    {
        allSlots = new List<GameObject>();

        hoverYOffset = slotSize * 0.01f;

        emptySlots = slots;

        inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft)   + slotPaddingLeft;

        inventoryHight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

        inventoryRect = GetComponent<RectTransform>();

        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHight);

        int columns = slots / rows;
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);

                RectTransform slotRect = newSlot.GetComponent<RectTransform>();

                newSlot.name = "Slot";

                newSlot.transform.SetParent(this.transform.parent);

                slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x),
                    -slotPaddingTop * (y + 1) - (slotSize * y));

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize * canvas.scaleFactor);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize * canvas.scaleFactor);

                allSlots.Add(newSlot);


            }
        }


    }

   

    
    public bool AddItem(Item item)
    {
        if (item.maxSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        else
        {
            foreach (GameObject slot in allSlots)
            {
                Slot tmp = slot.GetComponent<Slot>();

                if (!tmp.IsEmpty)
                {
                    if (tmp.CurrentItem.type == item.type && tmp.IsAvaible)
                    {
                        if (!movingSlot.IsEmpty && clicked.GetComponent<Slot>() == tmp.GetComponent<Slot>())
                        {
                            continue;
                        }
                        else
                        {
                            tmp.AddItem(item);
                            return true;
                        }
                        

                    }
                }
            }
            if (emptySlots > 0)
            {
                PlaceEmpty(item);
            }
        }
        return false;
    }
    bool PlaceEmpty(Item item)
    {
        if (emptySlots > 0)
        {
            foreach (GameObject slot in allSlots)
            {
                Slot tmp = slot.GetComponent<Slot>();
                if (tmp.IsEmpty)
                {
                    tmp.AddItem(item);
                    emptySlots--;
                    return true;
                }
            }
        }
        return false;
    }

    public void MoveItem(GameObject clicked)
    {
        Inventory.clicked = clicked;

        if (!movingSlot.IsEmpty)
        {
            Slot tmp = clicked.GetComponent<Slot>();

            if (tmp.IsEmpty)
            {
                tmp.AddItems(movingSlot.Items);
                movingSlot.Items.Clear();
                Destroy(GameObject.Find("Hover"));
            }
            else if (!tmp.IsEmpty && movingSlot.CurrentItem.type == tmp.CurrentItem.type && tmp.IsAvaible)
            {
                MergeStacks(movingSlot, tmp);
            }
        }
        else if (from == null && canvasGroup.alpha == 1 && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.gray;
                CreateHoverIcon();
               
            }
        }

        else if (to == null && !Input.GetKey(KeyCode.LeftShift))
        {
            to = clicked.GetComponent<Slot>();
            Destroy(GameObject.Find("Hover"));
        }
        if (to != null && from != null)
        {
            Stack<Item> tmpTo = new Stack<Item>(to.Items);
            to.AddItems(from.Items);

            if (tmpTo.Count == 0)
            {
                from.ClearSlot();
            }
            else
            {
                from.AddItems(tmpTo); 
            }


            from.GetComponent<Image>().color = Color.white;
            to = null;
            from = null;
            Destroy(GameObject.Find("Hover"));
        }
    }

    void CreateHoverIcon()
    {
        hoverObject = (GameObject)Instantiate(iconPrefab);
        hoverObject.GetComponent<Image>().sprite = clicked.GetComponent<Image>().sprite;
        hoverObject.name = "Hover";


        RectTransform hoverTransform = hoverObject.GetComponent<RectTransform>();
        RectTransform clickedTransform = clicked.GetComponent<RectTransform>();

        hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, clickedTransform.sizeDelta.x);
        hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, clickedTransform.sizeDelta.y);

        hoverObject.transform.SetParent(GameObject.Find("Canvas").transform, true);

        hoverObject.transform.localScale = clicked.gameObject.transform.localScale;

        hoverObject.transform.GetChild(0).GetComponent<Text>().text = movingSlot.Items.Count > 1 ? movingSlot.Items.Count.ToString() : string.Empty;
    }

    void PutItemBack()
    {
        if (from != null)
        {
            Destroy(GameObject.Find("Hover"));
            from.GetComponent<Image>().color = Color.white;
            from = null;
        }
        else if (!movingSlot.IsEmpty)
        {
            Destroy(GameObject.Find("Hover"));
            foreach (Item item in movingSlot.Items)
            {
                clicked.GetComponent<Slot>().AddItem(item);

            }
            movingSlot.ClearSlot();
        }
        selectStackSize.SetActive(false);
    }

    public void SetStackInfo(int maxStackCount)
    {
        selectStackSize.SetActive(true);
        splitAmount = 0;
        this.maxStackCount = maxStackCount;
        stackText.text = splitAmount.ToString();
    }

    public void SplitStack()
    {
        selectStackSize.SetActive(false);

        if (splitAmount == maxStackCount)
        {
            MoveItem(clicked);
        }
        else if (splitAmount > 0)
        {
            movingSlot.Items = clicked.GetComponent<Slot>().RemoveItems(splitAmount);

            CreateHoverIcon();
        }
    }
    
    public void ChangeStackText (int i)
    {
        splitAmount += i;
        if (splitAmount < 0)
        {
            splitAmount = 0;
        }
        if (splitAmount > maxStackCount)
        {
            splitAmount = maxStackCount;
        }

        stackText.text = splitAmount.ToString();
    }
    public void MergeStacks(Slot source, Slot destination)
    {
        int max = destination.CurrentItem.maxSize - destination.Items.Count;

        int count = source.Items.Count < max ? source.Items.Count : max;

        for (int i = 0; i < count; i++)
        {
            destination.AddItem(source.RemoveItem());
            hoverObject.transform.GetChild(0).GetComponent<Text>().text = movingSlot.Items.Count.ToString();
        }
        if (source.Items.Count == 0)
        {
            source.ClearSlot();
            Destroy(GameObject.Find("Hover"));
        }
    }
    private IEnumerator FadeOut()
    {
        fadingOut = true;
        if (fadingOut)
        {
            fadingOut = true;
            fadingIn = false;
            StopCoroutine("FadeIn");

            float startAlpha = canvasGroup.alpha;

            float rate = 1.0f / fadeTime;


            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }
            canvasGroup.alpha = 0;
            fadingOut = false;
            fadingIn = true;
        }
    }
    private IEnumerator FadeIn()
    {
        fadingIn = true;
        if (fadingIn)
        {
            fadingOut = false;
            fadingIn = true;           
            StopCoroutine("FadeOut");

            float startAlpha = canvasGroup.alpha;

            float rate = 1.0f / fadeTime;


            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, 1, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }
            canvasGroup.alpha = 1;
            fadingIn = false;
        }
    }

    private void Start()
    {
        canvasGroup = transform.parent.GetComponent<CanvasGroup>();

        CreateLayout();

        movingSlot = GameObject.Find("MovingSlot").GetComponent<Slot>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!eventSystem.IsPointerOverGameObject(-1) && from != null)
            {
                from.GetComponent<Image>().color = Color.white;
                from.ClearSlot();
                Destroy(GameObject.Find("Hover"));
                to = null;
                from = null;

                emptySlots++;
            }
            else if (!eventSystem.IsPointerOverGameObject(-1) && !movingSlot.IsEmpty)
            {
                movingSlot.ClearSlot();
                Destroy(GameObject.Find("Hover"));
            }
        }
        if (hoverObject != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition,
                canvas.worldCamera, out position);
            position.Set(position.x, position.y - hoverYOffset);
            hoverObject.transform.position = canvas.transform.TransformPoint(position);
        }
        if (Input.GetKeyDown(KeyCode.B)) // Olmad�
        {
            if (canvasGroup.alpha > 0)
            {
                StartCoroutine("FadeOut");
                PutItemBack();

            }
            else
            {
                StartCoroutine("FadeIn");

            }
        }
    }
}
