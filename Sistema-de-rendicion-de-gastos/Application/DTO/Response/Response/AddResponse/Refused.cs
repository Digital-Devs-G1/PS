using Application.Dto.Response.StatusResponseNS;
using System.Collections.Immutable;

namespace Application.Dto.Response.AddResponse
{
    public class Refused<EntityRequest>
    {
        public EntityRequest RefusedElem { get; }
        public ImmutableList<StatusResponse> Errors { get; }

        public Refused(EntityRequest elem, ImmutableList<StatusResponse> errors)
        {
            RefusedElem = elem;
            Errors = errors;
        }
    }
}
