using System;
using System.Xml.Linq;



namespace Core.Helpers {
  abstract public class XElementConvertable<T> {
    abstract public XElement ToXElement();

    static public T FromXElement(XElement element) {
      throw new NotImplementedException();
    }
  }
}
