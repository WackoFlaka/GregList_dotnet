namespace greglist_dotnet.Repositories;

public class HouseRepository
{
    private readonly IDbConnection _db;

    public HouseRepository(IDbConnection db)
    {
        _db = db;
    }

    internal List<House> GetHouses()
    {
        string sql = "SELECT * FROM houses;";

        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;
    }

    internal House GetHouseById(int houseId)
    {
        string sql = "SELECT * FROM houses WHERE id = @id;";
        House house = _db.Query<House>(sql, new { id = houseId }).FirstOrDefault();
        return house;
    }

    internal House CreateHouse(House data)
    {
        string sql = @"INSERT INTO houses(sqft, bedrooms, bathrooms, imgURL, description, price, creatorId) VALUES(@Sqft, @Bedrooms, @Bathrooms, @ImgURL, @Description, @Price, @CreatorId);
        
        SELECT * FROM houses WHERE id = LAST_INSERT_ID();";

        House house = _db.Query<House>(sql, data).FirstOrDefault();
        return house;
    }

    internal void DeleteHouse(int houseId)
    {
        string sql = "DELETE FROM houses WHERE id = @houseId LIMIT 1;";
        _db.Execute(sql, new { houseId });
    }

    internal House UpdateHouse(House ToUpdate)
    {
        string sql = @"UPDATE houses SET sqft = @Sqft, bedrooms = @Bedrooms, bathrooms = @Bathrooms, imgURL = @ImgURL, description = @Description, price = @Price WHERE id = @id LIMIT 1;
        SELECT * FROM houses WHERE id = @Id;";

        House house = _db.Query<House>(sql, ToUpdate).FirstOrDefault();
        return house;
    }
}