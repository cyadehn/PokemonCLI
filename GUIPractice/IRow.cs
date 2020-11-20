using System.Collections.Generic;

namespace GUIPractice
{
    public interface IRow
    {
        List<IWindow> Windows { get; }
        void OpenWindow(IWindow window);
        void DistributeWindows();
        void CloseWindow(IWindow window);
    }
}
