# example-aspnet-web-api

ASP.NET At Your Service: Web API
https://code.tutsplus.com/categories/aspnet-web-api/courses

- [Fiddler API Tester](https://www.telerik.com/fiddler)
- Project > Properties > Don't Open A Page - Great for creating web api since it won't open up a page, but instead would just run the program and allow you to fire request against the API without having to close a browser or deal with a browser window.
- By default you need to use `id` due to
```chsarp
//App_Start/WebApiConfig
config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);

//Controller
public int Get(int number) //this won't work, what will trigger this is /api/test/?number=5 since it needs to be
public int Get (int id)

// this would work because it has Get in the name for /api/test/?number=5
public int GetNumber(int number) 

//this will work due to the attribute for /api/test/?number=5
[HttpGet]
public int IWantANumber(int number) 
```
- Accept: application/json
```csharp
publc HttpResponseMessage Get() {
  return Request.GetResponse(HttpStatusCode.Ok, "some body message");
}

public IHttpResponseResult Get() {
  return Ok( $some_obj_that_will_show_in_body ); //return class that represence the status code, this is a better approach
}

// Will work because the default route is {id} and an integer
public IHttpResponseResult Post(int id) {
  return Ok(id);
}
 
// If its not an ID like the one before, you need to specify it in the body or uri [FromBody/FromUri]
// if from URI, /api/test?id=1&desc=test
public IHttpResponseResult Post ([FromBody]Sample s) {
  return Ok(s.id);
}
``` 
- `jsonFormatter.SerializerSettings.DateFormatHandling`

# Project #
- http://localhost:50408/api/game
- http://localhost:50408/api/player
	- http://localhost:50408/api/player/1
	- POST and DELETE

## 4.3 Entity Framework and Code First ##
- *New > Project > ASP.NET Application C# > Web Api*
- *Reference (in Solution Explorer) -> Manage Nuget Package -> Search for Entity Framework* (Entity Framework is Microsoft's recommended data access technology for new applications)
- A user entity was created (*Entities/User.cs*) that will map to the database in the CF approach.
- *AppDBContext.cs* was created (anything that is a context should be suffix as DBContext) to map the entity to a database.
- In *Package Manager Console* run `Enable-Migrations` and a *Migrations* folder is created.
- `Add-Migration Initial` to create our first migration so Entity Framework knows how to map to the database.
- `Update-Database` any migration not been run, it will apply the migrations.  It will also run seed.
- In *Server Explorer* click on *Connect to Database* icon and then
	- Server name: (LocalDb)\MSSQLLocalDB ref ~~(localdb)\v11.0~~
	- Select or enter a database name: soemthing with DEFAULTCONNECTION, very long string
- Create Account entity (AppDBContext.cs, Entites/Account.cs, User.cs) and then add a new `Add-NMigration Added_Account`
- Add something like this in the web.config
```xml
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-stats-20180117095623.mdf;Initial Catalog=aspnet-api.nlt.to-20180117095623;Integrated Security=True;MultipleActiveResultSets=true" providerName="System.Data.SqlClient" />
  </connectionStrings>
```

## 4.5 Repository and Service Layer patterns ##
- Everything inherits from EntityBase so that the `ID` is kept dry.
- The *ReportingBase.cs and EntityBase.cs* are `abstract` since you'll never need to instantiate these class directly since they don't provide any value other than a template class for those that inherits from it.
- `EntityBase` also inherits from `ReportingBase`
- In Team, `public virtual ICollection<Player> Players { get; set; }` represents that a Team can have many players.  But in Player, `public virtual Team Team { get; set; }` represents that a player can only be represented by one team.  As you can see, the definition is on both objects.
- *StatsDBContext.cs* is outside the Entities folder since its a DB Context.  And this will map all out entities (Game, Team Player, and GameEvent) to the database.
- Because there are 2 migrations, you may need to remove one or refactor.  Then when you `Update-Database` you may need to create a new Data Connection.
- Seed is in *Configuration.cs*
![database table]: https://github.com/sarn1/aspnet-example-web-api/blob/master/readme_resources/tables.JPG "Database tables"
- All of this pattern allows for easy service layer to do the following:
```csharp
	var service = new StatsService();
	service.Player.Get();
	service.Teams.Get(1);
	service.Player.Update();
```

## 4.7 Model Validator ##
- [ModelValidator] code is in *Filter/ModelValidatorAttributes.cs* and is used in *PlayerController.cs*

## 4.8 More Actions ##
- `[DatabaseGenerated(DatabaseGeneratedOption.Computed)]` in *ReportingBase.cs*
![database getdate]: https://github.com/sarn1/aspnet-example-web-api/blob/master/readme_resources/getdate.JPG "Database getdate"



## 4.9 Custom Routing ##
```csharp
// WebApiConfig.cs

// custom route
config.Routes.MapHttpRoute(
	name: "GameEvent",
	routeTemplate: "api/game/events",
	defaults: new { controller = "game", action = "CreateEvent" }
);

// goes to GameEcontroller.cs 
[ModelValidator]
public IHttpActionResult CreateEvent([FromBody] GameEventModel gameEventModel)
```


