namespace Doktr.Xml.XmlDoc.SectionParsers;

public class RemarksSectionParser : ISectionParser
{
    public string Tag => "remarks";

    public void ParseSection(IXmlDocProcessor processor, RawXmlDocEntry entry)
    {
        processor.ExpectElement(Tag);
        while (processor.Lookahead is not XmlEndElementNode)
            entry.Remarks.Add(processor.NextFragment());

        processor.ExpectEndElement(Tag);
    }
}