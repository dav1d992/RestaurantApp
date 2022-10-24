
namespace API.Repositories;

public class RestaurantRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public RestaurantRepository(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<RestaurantDto> AddRestaurant(RestaurantDto restaurantDto)
    {

        var restaurant = _mapper.Map<Restaurant>(restaurantDto);

        restaurant.Name = restaurantDto.Name.ToUpper();
        restaurant.Cvr = restaurantDto.Cvr;
        restaurant.ImageURL = restaurantDto.ImageURL;
        restaurant.Username = restaurantDto.Username;

        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();

        return new RestaurantDto
        {
            Name = restaurantDto.Name.ToUpper(),
            Cvr = restaurantDto.Cvr,
            ImageURL = restaurantDto.ImageURL,
            Username = restaurantDto.Username
        };
    }
}
