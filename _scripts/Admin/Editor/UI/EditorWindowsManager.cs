using Pryanik._scripts.Admin.Editor;
using Pryanik.Db.Models;

namespace Pryanik.Admin.Editor.UI
{
    public interface IEditorWindowsManager
    {
        void OpenCreateWindow(EditorObject editorObject);
        void OpenUpdateWindow(EditorObject editorObject, ModelBase model);
    } 
    
    public class EditorWindowsManager
    {
        
    }
}