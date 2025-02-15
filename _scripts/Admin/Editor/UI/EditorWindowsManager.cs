using System.Threading.Tasks;
using Pryanik.Db.Models;

namespace Pryanik.Admin.Editor.UI
{
    public interface IEditorWindowsManager
    {
        Task<ModelBase> OpenCreateWindow(EditorObject editorObject, int upperId);
        Task<ModelBase> OpenUpdateWindow(EditorObject editorObject, ModelBase model);
    } 
    
    public class EditorWindowsManager
    {

        private bool _isWindowOpened = false;
        
    }
}