using TMPro;
using UnityEngine;

public class Slot_Info : MonoBehaviour
{
    [SerializeField] private Transform camvas;
    [SerializeField] private GameObject infoUi;
    private GameObject currentInfoUi;
    private TMP_Text itemName, itemDesc, itemGrade, itemPrice;
    private CanvasGroup infoAlpha;

    private void Awake()
    {
        currentInfoUi = Instantiate(infoUi, Input.mousePosition, Quaternion.identity, camvas);
    }
    private void Start()
    {
        infoAlpha = currentInfoUi.GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        Vector3 uiDir = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

        currentInfoUi.transform.position = uiDir;
    }

    public void GetInfo()
    {
        print("����");
        SlotSO slotSO = GetComponent<Slot>().slot;

        if (slotSO == null)
        {
            print("����");
            return;
        }

        if (slotSO.index != 20)
        {
            infoAlpha.alpha = 0.8f;

            #region text find

            itemName = currentInfoUi.transform.Find("i_name").GetComponent<TMP_Text>();
            itemDesc = currentInfoUi.transform.Find("i_Desc").GetComponent<TMP_Text>();
            itemGrade = currentInfoUi.transform.Find("i_Grade").GetComponent<TMP_Text>();
            itemPrice = currentInfoUi.transform.Find("i_Price").GetComponent<TMP_Text>();

            #endregion

            itemName.text = slotSO.items.Name;
            itemDesc.text = slotSO.items.Description;
            itemGrade.text = slotSO.items.Tier + "TIER";
            itemPrice.text = slotSO.items.Price.ToString();
        }
    }

    public void DelInfo()
    {
        infoAlpha.alpha = 0;
    }
}
