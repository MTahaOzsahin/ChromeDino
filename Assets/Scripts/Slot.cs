using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    Stack<Item> items;

    public Text stackTxt;

    public Sprite slotEmpty, slotHighlight;

   

    

    public bool IsEmpty
    {
        get { return items.Count == 0; }
    }

    public bool IsAvaible
    {
        get {return CurrentItem.maxSize > items.Count; }
    }
    public Item CurrentItem
    {
        get { return items.Peek(); }
    }

    public Stack<Item> Items { get => items; set => items = value; }

    private void Start()
    {
        items = new Stack<Item>();

        RectTransform slotRec = GetComponent<RectTransform>();

        RectTransform txtRect = stackTxt.GetComponent<RectTransform>();

        int txtScaleFactor = (int) (slotRec.sizeDelta.x * 0.60);
        stackTxt.resizeTextMaxSize = txtScaleFactor;
        stackTxt.resizeTextMinSize = txtScaleFactor;


        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRec.sizeDelta.x);
        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRec.sizeDelta.y);
        


    }
    public  void AddItem(Item item)
    {
        items.Push(item);

        if (items.Count > 1)
        {
            stackTxt.text = items.Count.ToString();
        }

        ChangeSprite(item.spriteNeutral, item.spriteHighlighted);
    }

    public void AddItems(Stack<Item> items)
    {
        this.items = new Stack<Item>(items);

        stackTxt.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

        ChangeSprite(CurrentItem.spriteNeutral, CurrentItem.spriteHighlighted);
    }

    void ChangeSprite(Sprite neutral, Sprite highlight)
    {
        GetComponent<Image>().sprite = neutral;


        SpriteState st = new SpriteState();

        st.highlightedSprite = highlight;
        st.pressedSprite = neutral;

        GetComponent<Button>().spriteState = st;
    }

    void useItem()
    {
        if (!IsEmpty)
        {
            items.Pop().Use();

            stackTxt.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

            if (IsEmpty)
            {
                ChangeSprite(slotEmpty, slotHighlight);
                Inventory.EmptySlots++;
            }
        }
    }

    public Stack<Item> RemoveItems(int amount)
    {
        Stack<Item> tmp = new Stack<Item>();
        for (int i = 0; i < amount; i++)
        {
            tmp.Push(items.Pop());
        }

        stackTxt.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

        return tmp;
    }

    public Item RemoveItem()
    {
        Item tmp;

        tmp = items.Pop();

        stackTxt.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

        return tmp;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && GameObject.Find("Hover") && Inventory.CanvasGroup.alpha > 0)
        {
            useItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Left && Input.GetKey(KeyCode.LeftShift) 
            && IsEmpty && !GameObject.Find("Hover"))
        {
            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(Inventory.Instance.canvas.transform as RectTransform, Input.mousePosition,
                Inventory.Instance.canvas.worldCamera, out position);

            Inventory.Instance.selectStackSize.SetActive(true);

            Inventory.Instance.selectStackSize.transform.position = Inventory.Instance.canvas.transform.TransformPoint(position);

            Inventory.Instance.SetStackInfo(items.Count);
        }
    }

    public void ClearSlot ()
    {
        items.Clear();
        ChangeSprite(slotEmpty, slotHighlight);
        stackTxt.text = string.Empty;
    }


    





}