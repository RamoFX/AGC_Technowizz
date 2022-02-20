using System.IO;



namespace Core {
  public partial class Layout {
    static public partial class FileSystem {
      static public void Move(string fromName, string toName) {
        if (!Exists(fromName))
          return;

        string fromPath = GetPath(fromName);
        string toPath = GetPath(toName);

        File.Move(fromPath, toPath);
      }

      static public void Rename(Entity current, string newName) {
        string oldName = current.Name;
        current.Name = newName;

        if (!Exists(oldName))
          return;

        Move(oldName, newName);
        Export(current);
      }

      static public void Delete(string name) {
        if (Exists(name)) {
          string path = GetPath(name);
          File.Delete(path);
        }
      }
    }
  }
}
