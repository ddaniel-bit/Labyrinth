using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using Newtonsoft.Json;

class UpdateDatabase
{
    public string adat1 { get; set; }
    public string adat2 { get; set; }
}
internal class Program
{
    private static void Main(string[] args)
    {
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "GhgUD8PCIPXYmjwdsG4WOuAS2z7CO2gMcFxr9FCu",
            BasePath = "https://danko-26b2a.firebaseio.com/"
        };
        IFirebaseClient client = new FirebaseClient(ifc);

        UpdateDatabase adatok = new UpdateDatabase()
        {
            adat1 = "ezegy",
            adat2 = "teszt"
        };
        var setter = client.Set("Adatok/2022", adatok);
        
    }
}