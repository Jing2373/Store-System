using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Jing.Feature.UI
{
    public interface IUIManager
    {
        void Init(Canvas main_canvas, Canvas pop_canvas, Dictionary<string, GameObject> mainUI, Dictionary<string, GameObject> popWindows, IObjectResolver resolver);
        void ShowPage(string pageName, bool hideCurrent = true);
        void OpenPopWindows(string popName);
        void Back();
        void BackHome();
        void Close();
        void ClosePopWindows();
        bool ConfirmPageIsDisplay(string page_name);

    }
}