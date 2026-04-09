using UnityEngine;

public class SSalCollect : MonoBehaviour
{
    public bool canSell=true;
    #region Values
    private Animator _animator;
    private readonly int _collectedHash = Animator.StringToHash("isCollected");
    [SerializeField] private ItemManager itemManager;
    #endregion
    #region Default Methods
    private void Awake()
    {
        #region Load Components
        _animator = GetComponent<Animator>();
        itemManager = GetComponent<ItemManager>();
        #endregion
        canSell = true;
    }
    public void Sell(int index, Items_ItemList item, int tier)
    {
        if (canSell && Time.timeScale != 0 && gameObject.GetComponent<ItemManager>().CheckItemTier(tier))
        {
            SlotManager.Instance.AddItem(index, this, item);
        }
    }

    public void AnimationStart()
    {
        SpawnManager.Instance.ItemRemove(gameObject);
        canSell = false;
        _animator.SetTrigger(_collectedHash);
    }
    #endregion
    #region Destroy Mehod
    public void AnimendCallback()
    {
        Destroy(gameObject);
    }
    #endregion
}