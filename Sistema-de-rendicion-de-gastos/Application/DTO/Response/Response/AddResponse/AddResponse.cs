using System.Collections.Immutable;

namespace Application.Dto.Response.AddResponse
{
    public class AddResponse<EntityRequest, EntityResponse>
    {
        public AddResponse(
            ImmutableList<Refused<EntityRequest>> refuseds,
            ImmutableList<EntityResponse> acepteds
            )
        {
            this.refuseds = refuseds;
            this.acepteds = acepteds;
        }

        public ImmutableList<Refused<EntityRequest>> refuseds { get; }
        public ImmutableList<EntityResponse> acepteds { get; }
    }
}
