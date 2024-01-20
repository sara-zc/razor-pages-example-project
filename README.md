## Razor Pages Example Project

| author | Sara Desouki |
|---|---|
| birth year | 20 Jan, 2024 |
| tech & tools | Razor Pages, MSSQL, ChartJs |

### Intro 
This project is intended as a an example project for CIE206 and CSAI202 students, of almost everything we will learn throughout the semester.

### Running the project
Clone the repo to your local machine, and open the solution in Visual Studio. It should run without any issues. If you get an error saying that the version of .net is different than the one you have installed, open up the `.csproj` file using any text editor, and replace the version written inside the `<TargetFramework>` with your installed .net version. Save the file and try running the project again. (disclaimer: this may not always work, especially if you're switching from a higher version to a lower version, because not all versions are backwards compatible. But as far as I know, you can switch from _.net6.0_ to _.net7.0_ using this approach without any problems.)

### Changing the Connection String
You'll find the database connection string inside `appsettings.json`. I've left the file in the repo for you to understand how it's done, but you'll need to replace the server name and the database name for it to work on your computer. 
The connection string is then called inside `DB.cs` using `config.GetConnectionString("CompanyDB")`. You can have multiple connection strings inside the appsettings.json. 

The connection string is considered sensitive data, so remember to add the appsettings.json file to `.gitignore` if you're going to publish your code as open source.