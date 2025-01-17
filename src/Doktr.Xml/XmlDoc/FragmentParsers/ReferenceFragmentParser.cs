using Doktr.Core.Models;
using Doktr.Core.Models.Collections;
using Doktr.Core.Models.Fragments;

namespace Doktr.Xml.XmlDoc.FragmentParsers;

public class ReferenceFragmentParser : IFragmentParser
{
    private const string Cref = "cref";
    private const string Href = "href";

    public string[] SupportedTags { get; } = { "see" };

    public DocumentationFragment ParseFragment(IXmlDocProcessor processor)
    {
        var start = processor.ExpectElementOrEmptyElement(SupportedTags);
        string name = ((IHasNameAndAttributes) start).Name;
        var attributes = ((IHasNameAndAttributes) start).Attributes;
        var replacement = start.Kind == XmlNodeKind.Element ? ParseReplacement(processor) : null;
        if (replacement is not null)
            processor.ExpectEndElement(name);

        if (attributes.TryGetValue(Cref, out string? cref))
            return ParseCodeReference(cref, replacement);
        if (attributes.TryGetValue(Href, out string? href))
            return ParseLinkReference(href, replacement);

        throw new XmlDocParserException("Expected a 'cref' or an 'href' attribute, but found neither.", start.Span);
    }

    private static CodeReferenceFragment ParseCodeReference(string cref, DocumentationFragmentCollection? replacement)
    {
        var reference = new CodeReference(cref);
        return new CodeReferenceFragment(reference)
        {
            Replacement = replacement
        };
    }

    private static LinkReferenceFragment ParseLinkReference(string href, DocumentationFragmentCollection? replacement)
    {
        return new LinkReferenceFragment(href)
        {
            Replacement = replacement
        };
    }

    private static DocumentationFragmentCollection ParseReplacement(IXmlDocProcessor processor)
    {
        var replacement = new DocumentationFragmentCollection();
        while (processor.Lookahead.IsNotEndElementOrNull())
            replacement.Add(processor.NextFragment());

        return replacement;
    }
}