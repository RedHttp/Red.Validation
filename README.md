## The RedHttp project is no longer maintained. See [Carter](https://github.com/CarterCommunity/Carter) for a similar low-ceremony experience.

# Red.Validation
### Extensions for FormValidator for creating Red middleware

[![GitHub](https://img.shields.io/github/license/redhttp/red.validation)](https://github.com/RedHttp/Red.Validation/blob/master/LICENSE.md)
[![Nuget](https://img.shields.io/nuget/v/red.validation)](https://www.nuget.org/packages/red.validation/)
[![Nuget](https://img.shields.io/nuget/dt/red.validation)](https://www.nuget.org/packages/red.validation/)
![Dependent repos (via libraries.io)](https://img.shields.io/librariesio/dependent-repos/nuget/red.validation)

## Example
Create middleware function
```csharp
public static readonly Func<Request, Response, Task<HandlerType>> ValidateLoginForm = ValidatorBuilder.New()
    .RequiresString("username", s => WithLength(s, MinUsernameLength, MaxUsernameLength))
    .RequiresString("password", s => WithLength(s, MinPasswordLength, MaxPasswordLength))
    .BuildRedFormMiddleware();
```
And then use it
```csharp
server.Get("/login", ValidateLoginForm, PerformLogin);
```
