# RemixRunDotNet

This is a simple example of using [Remix Run](https://remix.run/) with a [.NET](https://dotnet.microsoft.com) backend.

**How it works**

Like stated in the description, this is a _very_ simple example of using a .NET backend with Remix. The way it works is
as follows:

- Remix is setup to use an [express](https://expressjs.com/) server. This lets us use whatever server configuration we
  want.
- In this project, you'll see we chose to proxy all requests starting with `/api` to go to the .NET backend.
- Therefore, all requests to `/api/*` go to the .NET backend (both on the Remix server and client). All others are
  handled by Remix.

**The whole picture**

In reality, .NET is the person in charge here (in development). Take a look at [Program.cs](./src/WebApp/Program.cs).
You'll see this:

```c#
if (app.Environment.IsDevelopment())
{
    app.UseSpa(spaBuilder =>
    {
        spaBuilder.Options.PackageManagerCommand = "yarn";
        spaBuilder.Options.SourcePath = Path.GetFullPath("./RemixApp");

        spaBuilder.UseReactDevelopmentServer("dev");
    });
}
```

When launching this project, it will start a node process which will run `yarn dev` - building the Remix app and
watching for file changes just like usual.

We only want this to occur in development of course, so when deploying this application, you'll want to be sure the
Remix server is running independently. Feel free to set `BACKEND_URL` to wherever your backend is hosted. As long as
Remix can access it over the network, you're all set.

I'll leave it as an exercise to the user to build upon this. It should be quite doable to set this up for docker-compose
for example:

```yaml
services:
  backend:
    ...
    ports:
      - '5024:80'
  frontend:
    ...
    depends_on:
      - backend
    environment:
      - NODE_ENV=production
      - BACKEND_URL=http://backend
    ports:
      - '80:3000'
```

**Inspiration**

I love Node, React, and Remix. I also ❤ .NET, so let's use them all together!
