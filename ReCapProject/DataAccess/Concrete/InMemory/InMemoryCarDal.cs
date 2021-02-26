namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal /* : ICarDal */
    {
        /*
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear=2010,DailyPrice=280,Description="2010 model Gri Ford"},
                new Car { Id = 2, BrandId = 1, ColorId = 2, ModelYear=2011,DailyPrice=300,Description="2011 model Siyah Ford"},
                new Car { Id = 3, BrandId = 2, ColorId = 3, ModelYear=2009,DailyPrice=250,Description="2009 model Kırmızı Opel"},
                new Car { Id = 4, BrandId = 2, ColorId = 2, ModelYear=2012,DailyPrice=320,Description="2012 model Siyah Opel"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;            
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }
        */
    }
}