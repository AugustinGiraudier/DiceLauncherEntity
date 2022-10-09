# DiceLauncher


# Migrations 

Afin d'effectuer les migrations, placez vous dans le dossier ```DiceLauncher\Sources\EntitiesLib```  
Executez : ```dotnet ef migrations add migration_1```  
pour créer la migration des tables  
puis : ```dotnet ef database update --startup-project ..\Application\```  
pour créer la base de données dans le dossier Application
