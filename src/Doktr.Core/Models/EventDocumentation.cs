using Doktr.Core.Models.Signatures;

namespace Doktr.Core.Models;

public class EventDocumentation : MemberDocumentation, IHasVirtual
{
    public EventDocumentation(string name, MemberVisibility visibility, TypeSignature handlerType)
        : base(name, visibility)
    {
        HandlerType = handlerType;
    }
    
    public TypeSignature HandlerType { get; set; }
    public bool IsVirtual { get; set; } = false;
    public bool IsOverride { get; set; } = false;
    public bool IsSealed { get; set; } = false;
}