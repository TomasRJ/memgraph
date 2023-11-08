using Neo4j.Driver;
 
namespace MemgraphApp
{
    public class Program
    {
        public static void Main()
        {
            string message = "Hello, World!";
 
            using var _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.None);
            using var session = _driver.Session();
 
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
}