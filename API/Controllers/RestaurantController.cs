using System.Security.Principal;

namespace API.Controllers;
public class RestaurantController : BaseApiController
{
    private readonly RestaurantRepository _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IIdentity _identity;

    public RestaurantController(RestaurantRepository repo, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repo;
        _mapper = mapper;
        _userManager = userManager;
    }

    [Authorize(Policy = "RestaurantManagerRole")]
    [HttpPost("register")]
    public async Task<ActionResult<RestaurantDto>> Register(RestaurantDto restaurantDto)
    {
        var result = _repository.AddRestaurant(restaurantDto);

        return Ok(result);
    }
}
