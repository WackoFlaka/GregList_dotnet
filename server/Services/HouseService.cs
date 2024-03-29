namespace greglist_dotnet.Services;

public class HouseService
{
    private readonly HouseRepository _repository;

    public HouseService(HouseRepository repository)
    {
        _repository = repository;
    }

    internal List<House> GetHouses()
    {
        List<House> houses = _repository.GetHouses();
        return houses;
    }

    internal House GetHouseById(int houseId)
    {
        House house = _repository.GetHouseById(houseId);
        if (house == null)
        {
            throw new Exception($"Invaid id: {houseId}");
        }

        return house;
    }

    internal House CreateHouse(House data)
    {
        House house = _repository.CreateHouse(data);
        return house;
    }

    internal string DeleteHouse(int houseId, string userId)
    {
        House toDelete = GetHouseById(houseId);
        if (toDelete.CreatorId != userId)
        {
            throw new Exception("You do not have access to delete this house. Permission Denied.");
        }

        _repository.DeleteHouse(houseId);
        return "The house has been deleted.";
    }

    internal House UpdateHouse(int houseId, string userId, House data)
    {
        House ToUpdate = GetHouseById(houseId);
        if (ToUpdate.CreatorId != userId)
        {
            throw new Exception("You do not have access to update this house. Permission Denided");
        }

        ToUpdate.Sqft = data.Sqft ?? ToUpdate.Sqft;
        ToUpdate.Bedrooms = data.Bedrooms ?? ToUpdate.Bedrooms;
        ToUpdate.Bathrooms = data.Bathrooms ?? ToUpdate.Bathrooms;
        ToUpdate.ImgURL = data.ImgURL ?? ToUpdate.ImgURL;
        ToUpdate.Description = data.Description ?? ToUpdate.Description;
        ToUpdate.Price = data.Price ?? ToUpdate.Price;

        House updatedHouse = _repository.UpdateHouse(ToUpdate);
        return updatedHouse;
    }
}