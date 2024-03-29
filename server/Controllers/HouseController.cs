namespace greglist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HouseController : ControllerBase
{
    private readonly HouseService _houseService;
    private readonly Auth0Provider _auth0provider;

    public HouseController(HouseService houseService, Auth0Provider auth0Provider)
    {
        _houseService = houseService;
        _auth0provider = auth0Provider;
    }

    [HttpGet]
    public ActionResult<List<House>> GetHouses()
    {
        try
        {
            List<House> houses = _houseService.GetHouses();
            return Ok(houses);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{houseId}")]
    public ActionResult<House> GetHouseById(int houseId)
    {
        try
        {
            House house = _houseService.GetHouseById(houseId);
            return Ok(house);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<House>> CreateHouse([FromBody] House data)
    {
        try
        {
            Account userinfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            data.CreatorId = userinfo.Id;
            House house = _houseService.CreateHouse(data);
            return house;
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{houseId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteHouse(int houseId)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _houseService.DeleteHouse(houseId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPut("{houseId}")]
    [Authorize]
    public async Task<ActionResult<House>> UpdateHouse(int houseId, [FromBody] House data)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            House house = _houseService.UpdateHouse(houseId, userInfo.Id, data);
            return Ok(house);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}