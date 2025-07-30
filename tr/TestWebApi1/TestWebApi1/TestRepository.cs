namespace TestWebApi1
{
    public class TestRepository : ITestRepository
    {
        public string GetTestString()
        {
            return "test";
        }
    }

    public interface ITestRepository
    {
        string GetTestString();
    }
}
