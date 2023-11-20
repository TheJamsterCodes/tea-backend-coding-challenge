# tea-backend-coding-challenge

## Steps to get up and running
1. Clone this repo to a local directory
2. However you choose, restore NuGet packages.
3. In the `BuilderServicesHelper.cs` class, ensure that the parameter for `isUsingSQLServer` is set to `true`.
    `builder.Services.AddSingleton<IDatabaseConnection>(db => new DatabaseConnection(isUsingSQLServer: true));`
4. Build and run the TEABackEndCodingChallenge