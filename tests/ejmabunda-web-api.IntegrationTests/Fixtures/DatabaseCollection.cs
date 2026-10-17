namespace ejmabunda_web_api.IntegrationTests.Fixtures;

[CollectionDefinition(nameof(DatabaseCollection))]
public class DatabaseCollection : ICollectionFixture<SqlServerFixture>;