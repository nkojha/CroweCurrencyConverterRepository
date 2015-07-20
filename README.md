# CroweCurrencyConverterRepository
Assignment for Crowe Horwath

Points of interest in the solution - 

1. I have implemented a factory for creating DifferentConversionSource(Yahoo Onada, XE) that My API is using and these sources are also configurable in API so no need to change anything in API if we add any new source for conversion.
2. Disabling a source is also configuration based so no need to redeploy the API if we disable any conversion source.
3. All the inputs to the API are sanitized for their legitimate values to avoid SQL injection
4. I have implemented a token based authentication for this API using OWIN oAuth.With this API will return a token for authenticated uses and then they can call secure operations.
5. Unit tests are provided and are successfully running for all the cases.
