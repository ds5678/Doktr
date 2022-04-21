using Doktr.Core.Models.Collections;

namespace Doktr.Core.Models;

public abstract class MemberDocumentation : ICloneable
{
    protected MemberDocumentation(string name, MemberVisibility visibility)
    {
        Name = name;
        Visibility = visibility;
    }

    public string Name { get; set; }
    public MemberVisibility Visibility { get; set; }
    public CodeReference? InheritDocumentationFrom { get; set; }
    public DocumentationFragmentCollection Summary { get; set; } = new();
    public DocumentationFragmentCollection Examples { get; set; } = new();
    public DocumentationFragmentCollection Remarks { get; set; } = new();
    public ProductVersionsSegmentCollection AppliesTo { get; set; } = new();
    public bool InheritsDocumentation => InheritDocumentationFrom.HasValue;

    public abstract MemberDocumentation Clone();

    object ICloneable.Clone() => Clone();
    
    protected virtual void CopyDocumentationTo(MemberDocumentation other)
    {
        other.InheritDocumentationFrom = InheritDocumentationFrom;
        other.Summary = Summary.Clone();
        other.Examples = Examples.Clone();
        other.Remarks = Remarks.Clone();
        other.AppliesTo = AppliesTo.Clone();
    }
}