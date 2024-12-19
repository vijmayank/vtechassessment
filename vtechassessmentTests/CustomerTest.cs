using Moq;
using vtechassessment.Models;
using vtechassessment.Services;

namespace vtechassessmentTests
{
    public class CustomerTest
    {
        private readonly Mock<ICustomerService> _customerService;

        public CustomerTest() {
            _customerService = new Mock<ICustomerService>();
            _customerService.Setup(x => x.GetAll()).Returns(() => GetallCustomers());
                }

        private static List<Customer> GetallCustomers()
        {
            return [
                new(){
                CustomerId = Guid.Parse("b6f7c3c5-e7f6-47a9-bd4a-ada698e8c12d"),
                Email = "test@test.com",
                FirstName = "fNameTest",
                MiddleName = "mNameTest",
                LastName = "lastNameTest",
                PhoneNumber = "416-432-9987"
                },
            new(){
                CustomerId = Guid.Parse("a3e9b2c1-95f8-4c7e-bb2d-6f2a9f631c4f"),
                Email = "test@test1.com",
                FirstName = "fNameTest1",
                MiddleName = "mNameTest1",
                LastName = "lastNameTest1",
                PhoneNumber = "416-432-9984"
            }];
        }

        [Theory]
        [InlineData(2)]
        public void Test1(int count)
        {
            var results = _customerService.Object.GetAll();
            Assert.Equal(count, results.Count);
        }
    }
}
