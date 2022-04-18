using Doktr.Core.Models.Collections;

namespace Doktr.Core.Models.Fragments;

public class ItalicFragment : IDocumentationFragment
{
    public DocumentationFragmentCollection Children { get; set; } = new();

    public void AcceptVisitor(IDocumentationFragmentVisitor visitor) => visitor.VisitItalic(this);
}