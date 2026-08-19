using UnityEngine;
using UnityEngine.UI;
using Jing.Tools;
using TMPro; // 確保有引入 TMP

namespace Jing.Feature.UI
{
    // 1. 定義一個列舉，作為介面上的下拉選單
    public enum UIBindType
    {
        AutoDetect, // 預設：自動偵測
        Transform,  // 強制抓取 Transform
        ButtonAdv,
        Button,
        TMP_Text,
        Image,
        RawImage,
        Slider,
        Dropdown
    }

    public class UIBinder : MonoBehaviour
    {
        public string Name;
        public UIBindType BindType = UIBindType.AutoDetect;
        public Component Target;

        private void OnValidate()
        {
            Name = gameObject.name;

            // 3. 如果是自動偵測，就維持你原本的優先層級邏輯
            if (BindType == UIBindType.AutoDetect)
            {
                Target = (Component)GetComponent<Button>() ??
                         (Component)GetComponent<TMP_Text>() ??
                         (Component)GetComponent<Image>() ??
                         (Component)GetComponent<RawImage>() ??
                         (Component)GetComponent<Slider>() ??
                         (Component)GetComponent<TMP_Dropdown>() ??
                         transform;
            }
            else
            {
                // 4. 如果有強制指定，就根據下拉選單去抓對應的元件
                switch (BindType)
                {
                    case UIBindType.Transform: Target = transform; break;
                    case UIBindType.Button: Target = GetComponent<Button>(); break;
                    case UIBindType.TMP_Text: Target = GetComponent<TMP_Text>(); break;
                    case UIBindType.Image: Target = GetComponent<Image>(); break;
                    case UIBindType.RawImage: Target = GetComponent<RawImage>(); break;
                    case UIBindType.Slider: Target = GetComponent<Slider>(); break;
                    case UIBindType.Dropdown: Target = GetComponent<TMP_Dropdown>(); break;
                }

                // 防呆機制：如果你指定了 Image，但物件身上其實沒有 Image，就退回 Transform 避免報錯
                if (Target == null)
                {
                    Debug.LogWarning($"[{Name}] 找不到指定的元件類型，已自動退回 Transform！");
                    Target = transform;
                }
            }
        }
    }
}