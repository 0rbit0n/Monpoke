namespace Monpoke.Tests
{
    class TestEnvironment : IEnvironment
    {
        public void Exit(int exitCode) => ExitedCode = exitCode;

        public int? ExitedCode { get; private set; }
    }
}
