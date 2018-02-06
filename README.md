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
- New > Project > ASP.NET Application C# > Web Api