namespace TestWebApi1
{
    public class TestService: ITestService
    {
        private readonly ITestRepository _testRepository;
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public string GetTestString()
        {
            return _testRepository.GetTestString();
        }
    }
    
    public interface ITestService
    {
        string GetTestString();
    }
}
