# Monpoke

## Environment
Make sure you have [Net Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) installed

## Build/Test/Run instructions

### Building project
`dotnet publish Monpoke -c Release -o ./out`

### Running tests
`dotnet test`

### Running game from input stream
`cat input.txt | ./out/Monpoke.exe`

### Running game from file
`./out/Monpoke.exe ./input.txt`