using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(SSalCollect))]
[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    #region Values
    private SSalCollect ssaCollect;
    [SerializeField] private Item_ImageSO item_ImageSO;
    public Items items;
    [SerializeField] private int itemNum;

    private string name;
    [SerializeField] private long price;
    private string description;
    private Items_ItemList itemList;

    public Action<int,Items_ItemList, int> isClick;

    [SerializeField] private SpriteLibrary spriteLibrary;
    [SerializeField] private BoxCollider2D collider2D;
    private SpriteRenderer spriteRenderer;
    #endregion
    #region Default Methods
    private void Awake()
    {
        ssaCollect = GetComponent<SSalCollect>();
        spriteLibrary = GetComponent<SpriteLibrary>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        UpdateItemInfo();
        #region Action Link
        isClick += ssaCollect.Sell;
        #endregion
    }

    private void Update()
    {
        spriteRenderer.sortingOrder = -(int)transform.position.y;
    }

    private void OnValidate()
    {
        if (items != null && items.ItemList[itemNum] != null && item_ImageSO.Item_Assets[itemNum] != null)
            UpdateItemInfo();
    }
    private void OnMouseUp()
    {
        isClick?.Invoke(itemNum, itemList, items.ItemList[itemNum].Tier);
    }
    private void OnDestroy()
    {
        isClick -= ssaCollect.Sell;
    }
    #endregion
    #region Update Methods
    private void UpdateItemInfo()
    {
        name = items.ItemList[itemNum].Id;
        gameObject.name = name;
        price = (long)items.ItemList[itemNum].Price;
        description = items.ItemList[itemNum].Description;
        spriteLibrary.spriteLibraryAsset = item_ImageSO.Item_Assets[itemNum];
        collider2D.size = item_ImageSO.ColliderSize[itemNum];
        itemList =  items.ItemList[itemNum];
    }
    #endregion
}
