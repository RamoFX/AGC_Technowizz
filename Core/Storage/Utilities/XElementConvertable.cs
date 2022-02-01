using System;
using System.Xml.Linq;



namespace Core.Storage.Utilities {
  abstract class XElementConvertable<T> {
    abstract public XElement ToXElement();

    static public T FromXElement(XElement element) {
      throw new NotImplementedException();
    }
  }
}
