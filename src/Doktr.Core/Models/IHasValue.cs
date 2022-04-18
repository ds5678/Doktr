using Doktr.Core.Models.Collections;
using Doktr.Core.Models.Signatures;

namespace Doktr.Core.Models;

public interface IHasValue
{
    TypeSignature Type { get; set; }
    DocumentationFragmentCollection Value { get; set; }
}