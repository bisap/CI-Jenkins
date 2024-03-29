FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build-image

WORKDIR /home/app

COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done

RUN dotnet restore

COPY . .

RUN dotnet test --verbosity=normal --results-directory /TestResults/ --logger "trx;LogFileName=test_results.xml" ./UnitTestCaseCommittee-Microservices/UnitTestCaseCommittee-Microservices.csproj

RUN dotnet publish ./Committee-Microservices/Committee-Microservices.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /publish

COPY --from=build-image /publish .

COPY --from=build-image /TestResults /TestResults

ENTRYPOINT ["dotnet", "committee-microservices.dll"]
