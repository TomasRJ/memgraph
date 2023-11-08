using Neo4j.Driver;
 
namespace MemgraphApp
{
  public class Program : IDisposable
  {
    private readonly IDriver _driver;
 
    public Program(string uri, string user, string password)
    {
      _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
    }
 
    public void PrintGreeting(string message)
    {
      using (var session = _driver.Session())
      {
        var greeting = session.ExecuteWrite(tx =>
        {
          var result = tx.Run("CREATE (n:FirstNode) " +
                    "SET n.message = $message " +
                    "RETURN 'Node '  + id(n) + ': ' + n.message",
            new { message });
          return result.Single()[0].As<string>();
        });
        Console.WriteLine(greeting);
      }
    }
 
    public void Dispose()
    {
      _driver?.Dispose();
    }
 
    public static void Main()
    {
      using (var greeter = new Program("bolt://localhost:7687", "", ""))
      {
        greeter.PrintGreeting("Hello, World!");
      }
    }
  }
}