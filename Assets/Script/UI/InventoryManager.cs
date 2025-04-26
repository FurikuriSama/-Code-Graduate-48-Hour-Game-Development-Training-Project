using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // 引用背包面板
    public Button inventoryButton; // 引用背包按钮

    private void Start()
    {
        inventoryButton.onClick.AddListener(ToggleInventory); // 添加按钮点击事件
        inventoryPanel.SetActive(false); // 确保背包面板初始隐藏
    }

    private void ToggleInventory()
    {
        // 切换背包面板的显示状态
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
