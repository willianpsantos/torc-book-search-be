# torc-book-search

1. This project consists on the backend that offers an API to search books in a database. 
2. This project consists on some layers in order to keep easy manteinability and code decoupling, easing future unit and integration tests.

The layers of project are:

1. TorcBookSearch.API - It's the API itself, with controllers, endpoints and settings for database access, logging, etc.

2. TorcBookSearch.Contracts - Contains all contracts and interfaces that's going to be used over all other layers.

3. TorcBookSearch.Data - Contains the necessary components to connect, access and manage database. The project uses EntityFramework to connect and manage database, thought migrations.

4. TorcBookSearch.DependencyInjection - It's the entry point for all code and layers in the project. It combines all classes to interfaces and contracts defined into TorcBookSearch.Contracts project.

5. TorcBookSearch.Models - Contains all entities and data models used all over the project. The entities in this project are mapped in TorcBookSearch.Data project so that it defines all database tables structures, fields, types, etc. This project also contains other object types, such as Queries, which is request to filter data, requests, etc.

6. TorcBookSearch.Repositories - Contains the classes to manipulate database entities. They connect to database, retrieve data from database, create, update and delete data from database as well.

7. TorcBookSearch.UnitsOfWork - Contains classes that encapsulates business operations. In general, it gets all objects defined in other layers to use in a meaninful operation that represents something to business.

The project also contains a pipeline in Azure to build and deploy this project in Azure AKS.