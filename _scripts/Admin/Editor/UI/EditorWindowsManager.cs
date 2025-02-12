using System.Threading.Tasks;
using Pryanik._scripts.Admin.Editor;
using Pryanik.Db.Models;

namespace Pryanik.Admin.Editor.UI
{
    public interface IEditorWindowsManager
    {
        void OpenCreateWindow(EditorObject editorObject);
        void OpenUpdateWindow(EditorObject editorObject, ModelBase model);
        Task WindowOpenedWaiter();
    } 
    
    public class EditorWindowsManager
    {

        private bool _isWindowOpened = false;

        public async Task WindowOpenedWaiter()
        {
            _isWindowOpened = true;
            while (_isWindowOpened)
                await Task.Delay(5);

        }
    }
}