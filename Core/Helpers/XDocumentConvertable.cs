using System;
using System.Xml.Linq;



namespace Core.Helpers {
  abstract class XDocumentConvertable<T> {
    abstract public XDocument ToXDocument();

    static public T FromXDocument(XDocument document) {
      throw new NotImplementedException();
    }
  }
}
