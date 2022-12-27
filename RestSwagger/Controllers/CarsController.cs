using Microsoft.AspNetCore.Mvc;

namespace RestSwagger.Controllers;

// baseUrl.com/Books
[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    public static readonly List<Car> Cars = new();

    [HttpGet]
    public IEnumerable<Car> GetAll()
    {
        return Cars;
    }

    [HttpGet("{id:guid}")]
    public Car Get([FromRoute] Guid id)
    {
        return Cars.First(x => x.Id == id);
    }

    [HttpPost]
    public Car Create(Car car)
    {
        if (car.Id == Guid.Empty)
            car.Id = Guid.NewGuid();

        if (Cars.Any(x => x.Id == car.Id))
            throw new Exception("Car already exists");

        Cars.Add(car);
        return car;
    }

    [HttpPut("{id:guid}")]
    public Car Update([FromRoute] Guid id, [FromForm] Car car)
    {
        var oldBook = Cars.FirstOrDefault(x => x.Id == id);
        if (oldBook == null)
            throw new Exception("Car doesn't exists");

        Cars.Remove(oldBook);
        Cars.Add(car);
        return car;
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete([FromRoute] Guid id)
    {
        var oldBook = Cars.FirstOrDefault(x => x.Id == id);
        if (oldBook == null)
            throw new Exception("Car doesn't exists");

        Cars.Remove(oldBook);
        return Ok();
    }
}