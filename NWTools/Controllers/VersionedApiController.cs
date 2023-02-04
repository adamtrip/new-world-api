using Microsoft.AspNetCore.Mvc;

namespace NWTools.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
public class VersionedApiController : BaseApiController
{
}
